using System.Net;
using System.Web.Http.Results;
using Fenergo.Ui.Controllers.Api;
using Fenergo.Ui.Dtos;
using Fenergo.Ui.Models;
using Fenergo.Ui.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fenergo.Ui.Tests.Controllers
{
    [TestClass]
    public class TestProductController
    {
        [TestMethod]
        public void PostProduct_ShouldReturnSameProduct()
        {
            var controller = new HardwaresController(new HardwareRepository(new TestAppContext()));

            var item = GetDemoHardware();

            var result =
                controller.PostHardware(item) as CreatedAtRouteNegotiatedContentResult<HardwareDto>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Description, item.Description);
        }

        [TestMethod]
        public void PutProduct_ShouldReturnStatusCode()
        {
            var controller = new HardwaresController(new HardwareRepository(new TestAppContext()));

            var item = GetDemoHardware();

            var result = controller.PutHardware(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            var controller = new HardwaresController(new HardwareRepository(new TestAppContext()));

            var badresult = controller.PutHardware(999, GetDemoHardware());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetProduct_ShouldReturnProductWithSameID()
        {
            var context = new HardwareRepository(new TestAppContext());
            var controller = new HardwaresController(context);
            var hardware = controller.PostHardware(GetDemoHardware());
            var result = controller.GetHardware(3) as OkNegotiatedContentResult<Hardware>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public void GetProducts_ShouldReturnAllProducts()
        {
            var context = new TestAppContext();
            context.Hardwares.Add(new Hardware { Id = 1, Description = "Demo1", PurchasePrice = 20 });
            context.Hardwares.Add(new Hardware { Id = 2, Description = "Demo2", PurchasePrice = 30 });
            context.Hardwares.Add(new Hardware { Id = 3, Description = "Demo3", PurchasePrice = 40 });

            var controller = new HardwaresController(new HardwareRepository(context));
            var result = controller.GetHardwares() as TestHardwareDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteProduct_ShouldReturnOK()
        {
            var context = new TestAppContext();
            var controller = new HardwaresController(new HardwareRepository(context));
            var item = GetDemoHardware();
            controller.PostHardware(item);
            
            var result = controller.DeleteHardware(3) as OkNegotiatedContentResult<Hardware>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        HardwareDto GetDemoHardware()
        {
            return new HardwareDto { Id = 3, Description = "Demo name", PurchasePrice = 5 };
        }
    }
}
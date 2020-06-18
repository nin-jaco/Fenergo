using System.Linq;
using System.Net;
using System.Web.Http.Results;
using AutoMapper;
using Fenergo.Ui.App_Start;
using Fenergo.Ui.Controllers.Api;
using Fenergo.Ui.Dtos;
using Fenergo.Ui.Models;
using Fenergo.Ui.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fenergo.Ui.Tests.Controllers
{
    [TestClass]
    public class TestHardwareController : Profile
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            var mappingProfile = new MappingProfile();

        }

        [TestMethod]
        public void PostHardware_ShouldReturnSameHardware()
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
        public void PutHardware_ShouldReturnStatusCode()
        {
            var controller = new HardwaresController(new HardwareRepository(new TestAppContext()));

            var item = GetDemoHardware();

            var result = controller.PutHardware(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutHardware_ShouldFail_WhenDifferentID()
        {
            var controller = new HardwaresController(new HardwareRepository(new TestAppContext()));

            var badresult = controller.PutHardware(999, GetDemoHardware());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetHardware_ShouldReturnHardwareWithSameID()
        {
            var context = new HardwareRepository(new TestAppContext());
            var controller = new HardwaresController(context);
            var hardware = controller.PostHardware(GetDemoHardware()) as CreatedAtRouteNegotiatedContentResult<HardwareDto>;
            var result = controller.GetHardware(hardware.Content.Id) as OkNegotiatedContentResult<HardwareDto>;

            Assert.IsNotNull(result);
            Assert.AreEqual(hardware.Content.Id, result.Content.Id);
        }

        [TestMethod]
        public void GetHardwares_ShouldReturnAllHardwares()
        {
            var context = new TestAppContext();
            context.Hardwares.Add(new Hardware { Id = 1, IdHardwareType = 2, Description = "Demo name1", PurchasePrice = 5, IdPhoto = null, SerialNumber = "Abc123" });
            context.Hardwares.Add(new Hardware { Id = 2, IdHardwareType = 2, Description = "Demo name2", PurchasePrice = 5, IdPhoto = null, SerialNumber = "Abc123" });
            context.Hardwares.Add(new Hardware { Id = 3, IdHardwareType = 2, Description = "Demo name3", PurchasePrice = 5, IdPhoto = null, SerialNumber = "Abc123" });
            context.SaveChanges();

            var controller = new HardwaresController(new HardwareRepository(context));
            var result = controller.GetHardwares();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void DeleteHardware_ShouldReturnOK()
        {
            var context = new TestAppContext();
            var controller = new HardwaresController(new HardwareRepository(context));
            var item = controller.PostHardware(GetDemoHardware()) as CreatedAtRouteNegotiatedContentResult<HardwareDto>;

            var result = controller.DeleteHardware(item.Content.Id) as OkNegotiatedContentResult<HardwareDto>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Content.Id, result.Content.Id);
        }

        HardwareDto GetDemoHardware()
        {
            return new HardwareDto { Id = 1, IdHardwareType = 2, Description = "Demo name", PurchasePrice = 5, IdPhoto = null, SerialNumber = "Abc123"};
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fenergo.Ui.Dtos;
using Fenergo.Ui.ViewModels;

namespace Fenergo.Ui.Controllers
{
    public class HardwareController : Controller
    {
        // GET: Hardware
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            //var customer = Context.Customers.FirstOrDefault(p => p.Id == id);
            //if (customer == null) return HttpNotFound();

            var viewModel = new HardwareFormViewModel
            {
                //Customer = customer,
                //MembershipTypes = Context.MembershipTypes.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(HardwareDto hardwareDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new HardwareFormViewModel
            //    {
            //        Customer = customer,
            //        MembershipTypes = Context.MembershipTypes.ToList()
            //    };
            //    return View("CustomerForm", viewModel);
            //}

            //if (customer.Id == 0)
            //{
            //    Context.Customers.Add(customer);
            //}
            //else
            //{
            //    var dbCust = Context.Customers.FirstOrDefault(p => p.Id == customer.Id);
            //    //TryUpdateModel(dbCust);
            //    //automapper
            //    dbCust.Name = customer.Name;
            //    dbCust.DateOfBirth = customer.DateOfBirth;
            //    dbCust.MembershipTypeId = customer.MembershipTypeId;
            //    dbCust.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //}

            //Context.SaveChanges();

            return RedirectToAction("Index", "Hardware");
        }

        
    }
}
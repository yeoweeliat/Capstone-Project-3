using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Models;
using CustomerApp.DbContextCustomer;
using System.ComponentModel.DataAnnotations;
using CustomerApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;

namespace CustomerApp.Controllers
{

    [EnableCors("MyPolicy")]
    public class CustomerController : Controller
    {
        // add code for dependency injection
        CustomerDbContext custDbContext = null;
        public CustomerController(CustomerDbContext _custDbContext, IConfiguration configuration)
        {
            custDbContext = _custDbContext;
            string str = configuration["ConnString"];

        } // add breakpoint here to debug code to check str value
        //end code for DI



        //public IActionResult Index()
        //{
        //    return View("CustomerAdd");
        //}

        //public IActionResult Add(Customer obj)
        //{
        //    return View("CustomerAdd");
        //}


        int i = 0;

        public IActionResult AddScreen() // Display to the screen
        {

            // Code 1 -> for httpsession
            //get the current value
            if (HttpContext.Session.GetInt32("variablei") != null) // get the session variable if available
            {
                i = (int) HttpContext.Session.GetInt32("variablei");
            }

            i++;

            // send to browser to store it in cookies
            HttpContext.Session.SetInt32("variablei", i);


            //return View("CustomerAdd");

            return View("CustomerAdd", new CustomerViewModel());

            // add in empty viewmodel, so that it does not crash / invoke null exception
        }

        public IActionResult SearchScreen() // Display to the screen
        {
            return View("DisplayCustomer");
        }


        // move to CustomerAPIController (get function)
        /*
        public IActionResult Search(string customerName) // Execute search query
        {

            CustomerDbContext custDbContext = new CustomerDbContext();
            List<Customer> custs = (from temp in custDbContext.Customers
                                    where temp.customerName == customerName
                                    select temp).ToList<Customer>();

            return View("DisplayCustomer", custs);
        }
        */


        // move to CustomerAPIController (post function)
        /*
        // add method with DI

        //must put from body to accept body data from http
        public IActionResult Add([FromBody] Customer obj) // Add to DB using EF Core 
        {
            //obj.customerName = Request.Form["textCustomerName"]; //custom mapping
            //obj.address = Request.Form["textAddress"];

            // need to check validation
            var context = new ValidationContext(obj, null, null); //create instance of validation object

            var errorresult = new List<ValidationResult>(); // if no errors, errorresult = 0

            var check = Validator.TryValidateObject(obj,
                                    context,
                                    errorresult, true);


            // add 1 record to table
            // with DI

            if (check)
            {
                custDbContext.Customers.Add(obj);
                custDbContext.SaveChanges();
                List<Customer> custs = custDbContext.Customers.ToList<Customer>();

                //return View("DisplayCustomer", custs); // cannot be used for angular js

                //return Json(custs); // can be used for angular js -> goes to SuccessObserver() in app.component.ts
                return StatusCode(StatusCodes.Status200OK, custs); // goes to SuccessObserver()
            }
            else
            {
                //return View("CustomerAdd", errorresult);


                CustomerViewModel custvm = new CustomerViewModel();
                custvm.customer = obj;
                custvm.errors = errorresult;

                //return View("CustomerAdd", custvm); // cannot be used for angular js

                //return Json(errorresult); // goes to SuccessObserver(), which we dont want
                return StatusCode(StatusCodes.Status500InternalServerError, errorresult); // goes to ErrorObserver()



            }
        }
        */


        // add method without DI
        /*
        public IActionResult Add(Customer obj) // Add to DB using EF Core
        {

            // need to check validation
            var context = new ValidationContext(obj, null, null); //create instance of validation object

            var errorresult = new List<ValidationResult>(); // if no errors, errorresult = 0

            var check = Validator.TryValidateObject(obj,
                                    context,
                                    errorresult, true);


            // add 1 record to table
            // without DI

            if (check) {

            CustomerDbContext cust = new CustomerDbContext();
            cust.Customers.Add(obj); //add to database
            cust.SaveChanges(); // save changes

            //fetch all records from table and display to view
            List<Customer> custs = cust.Customers.ToList<Customer>();
            return View("DisplayCustomer", custs);
            }
            else
            {
                //return View("CustomerAdd", errorresult);


                CustomerViewModel custvm = new CustomerViewModel();
                custvm.customer = obj;
                custvm.errors = errorresult;

                return View("CustomerAdd", custvm);
            }
        
            
        }
        */


        public IActionResult Edit()
        {
            return View("CustomerEdit");
        }
    }
}

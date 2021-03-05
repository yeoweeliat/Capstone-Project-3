using CustomerApp.DbContextCustomer;
using CustomerApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


// we moved all our code in mvc controller to web api controller
// benefit of standardization: get,post,delete etc
namespace CustomerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {

        CustomerDbContext custDbContext = null;
        public CustomerAPIController(CustomerDbContext _custDbContext, IConfiguration configuration) // DI
        {
            custDbContext = _custDbContext;
            string str = configuration["ConnString"];
        }


        // change IEnumberable to IActionResult so that you can return both data and status code
        // GET: api/<CustomerAPIController>
        [HttpGet]
        public IActionResult Get() // IEnumerable can be replaced with List
        {

            //List<Customer> custs = (from temp in custDbContext.Customers select temp).ToList<Customer>(); // search/select all (LINQ)

            List<Customer> custs = custDbContext.Customers
                                                .Include(p => p.products)
                                                .ToList<Customer>(); //same line without LINQ


            //return StatusCode(StatusCodes.Status200OK, custs);
            return Ok(custs); // only for statuscode: 200, we have this shortcut

        }


        // type https://localhost:44385/api/CustomerAPI in browser to view json.



        // GET api/<CustomerAPIController>/5
        [HttpGet("{id}")] //change id to customerName since where clause is customerName, not id
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer obj) //replaces add method in customercontroller, shift code here. 
        {

            var context = new ValidationContext(obj, null, null); //create instance of validation object

            var errorresult = new List<ValidationResult>(); // if no errors, errorresult = 0

            var check = Validator.TryValidateObject(obj,context,errorresult, true);


            // add 1 record to table
            // with DI

            if (check)
            {
                custDbContext.Customers.Add(obj);
                custDbContext.SaveChanges();
                List<Customer> custs = custDbContext.Customers
                                        .Include(p => p.products) // change lazy loading to eager loading / explicit loading
                                        .ToList<Customer>();

                return StatusCode(StatusCodes.Status200OK, custs); // goes to SuccessObserver() // mark as IActionResult to remove error (red line under return)
                // return Ok (custs);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errorresult); // goes to ErrorObserver()
            }

        }
    

        // PUT api/<CustomerAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartEFCodeFirst.Models;

namespace ShoppingCartEFCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ShoppingContext _shoppingContext;

        public CustomerController()
        {
            _shoppingContext=new ShoppingContext();
            //_shoppingContext=shoppingContext;
        }

        [HttpGet]
        [Route("CustomerById/{id:int}")]
        public ActionResult<Customer> GetCustomerByID(int id)
        {
            var customer = _shoppingContext.Customers.SingleOrDefault(found => found.Id == id);
            if (customer != null)
                return Ok(customer);

            return NotFound();

        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public ActionResult<List<Customer>> GetCustomers()
        {
            throw new NotImplementedException();
            return Ok(_shoppingContext.Customers);
        }

        [HttpPost]
        [Route("AddCustomer")]
        public ActionResult<Customer> StoreCustomer(Customer customer)
        {
            
                _shoppingContext.Customers.Add(customer);
                _shoppingContext.SaveChanges();

                return Ok(_shoppingContext.Customers);
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e.Message);
            //}
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public ActionResult<Customer> UpdateCustomer(int id,Customer customer)
        {
            //try
            //{
            var _customer = _shoppingContext.Customers.SingleOrDefault(found => found.Id == id);
            _customer = customer;
            _shoppingContext.SaveChanges();

            return Ok(_shoppingContext.Customers);
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e.Message);
            //}

        }

    }
}

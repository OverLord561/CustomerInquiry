using System;
using CustomerInquiryWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Threading.Tasks;
using CustomerInquiryWebApi.ViewModels;
using CustomExceptions;

namespace CustomerInquiryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customerService;
        public CustomersController(ICustomersService customerService )
        {
            _customerService = customerService;
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new NoInquiryCriteriaException("No inquiry criteria").Message);
            }

            bool isValid = _customerService.IsCustomerIdValid(id);

            if (!isValid)
            {
                return BadRequest(new InvalidCustomerIDException("Invalid Customer ID").Message);
            }

            CustomerViewModel customer = await _customerService.GetDataByIdAsync(int.Parse(id));

            if (customer == null)
            {
                return NotFound();
            }

            return new JsonResult(new { StatusCode = StatusCodes.Status200OK, customer });
        }
        
        [HttpGet("get-by-email")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new NoInquiryCriteriaException("No inquiry criteria").Message);
            }

            bool isValid = _customerService.IsEmailValid(email);

            if (!isValid)
            {
                return BadRequest(new InvalidEmailException("Invalid Email").Message);
            }

            CustomerViewModel customer = await _customerService.GetDataByEmailAsync(email);

            if (customer == null)
            {
                return NotFound();
            }

            return new JsonResult(new { StatusCode = StatusCodes.Status200OK, customer });
        }


        [HttpGet("get-by-id-email")]
        public async Task<IActionResult> GetByIdAndEmail(string id, string email)
        {
            if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(email))
            {
                return BadRequest(new NoInquiryCriteriaException("No inquiry criteria").Message);
            }

            bool idIsValid = _customerService.IsCustomerIdValid(id);
            bool emailIsValid = _customerService.IsEmailValid(email);

            if (!idIsValid)
            {
                return BadRequest(new InvalidCustomerIDException("Invalid Customer ID").Message);
            }
            else if (!emailIsValid)
            {
                return BadRequest(new InvalidEmailException("Invalid Email").Message);
            }

            CustomerViewModel customer = await _customerService.GetDataByIdAndEmailAsync(int.Parse(id), email);

            if (customer == null)
            {
                return NotFound();
            }

            return new JsonResult(new { StatusCode = StatusCodes.Status200OK, customer });
        }

    }
}
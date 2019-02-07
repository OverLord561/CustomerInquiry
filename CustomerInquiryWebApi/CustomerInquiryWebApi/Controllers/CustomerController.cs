using CustomerInquiryWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Threading.Tasks;

namespace CustomerInquiryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ITransactionRepository _transactionRepository;
        public CustomerController(ICustomerService customerService, ITransactionRepository transactionRepository)
        {
            _customerService = customerService;
            _transactionRepository = transactionRepository;
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _customerService.GetDataByIdAsync(id);

            return new JsonResult(new { StatusCode = StatusCodes.Status200OK, data = data });
        }
    }
}
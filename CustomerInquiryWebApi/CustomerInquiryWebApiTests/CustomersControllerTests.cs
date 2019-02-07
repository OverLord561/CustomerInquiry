using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CustomerInquiryWebApi.Controllers;
using CustomerInquiryWebApi.Extensions;
using CustomerInquiryWebApi.Services;
using CustomerInquiryWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CustomerInquiryWebApiTests
{
    public class CustomersControllerTests
    {
        private readonly Mock<ICustomersService> _mockCustomerService;
        private string _email = "test@test.com";
        private string _customerId = "2";

        public CustomersControllerTests()
        {
            _mockCustomerService = new Mock<ICustomersService>();
        }

        [Fact]
        public async Task Action_GetCustomerByValidId_ReturnsJsonResult_Code200AndData()
        {
            //Arrange
            var customerId = "1";
            int code200 = StatusCodes.Status200OK;
            _mockCustomerService.Setup(serv => serv.GetDataByIdAsync(int.Parse(customerId)))
                .ReturnsAsync(GetCustomer);
            _mockCustomerService.Setup(serv => serv.IsCustomerIdValid(customerId))
                .Returns(PropertyIsValid);
            var controller = new CustomersController(_mockCustomerService.Object);

            //Act

            var result = await controller.GetById(customerId.ToString());
            var code = (result as JsonResult).Value.GetType().GetProperty("StatusCode").GetValue((result as JsonResult).Value);

            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(code200, code);
        }

        [Fact]
        public async Task Action_GetCustomerByValidId_ReturnsNotFound()
        {
            //Arrange
            var customerId = _customerId;
            _mockCustomerService.Setup(serv => serv.IsCustomerIdValid(customerId))
                .Returns(PropertyIsValid);
            _mockCustomerService.Setup(serv => serv.GetDataByIdAsync(int.Parse(customerId)))
                .ReturnsAsync((CustomerViewModel)null);
            var controller = new CustomersController(_mockCustomerService.Object);

            //Act
            var result = await controller.GetById(customerId.ToString());

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Action_GetCustomerByInValidId_ReturnsBadRequestAndMessage()
        {
            //Arrange
            var customerId = _customerId;
            var messageValue = "Invalid Customer ID";
            _mockCustomerService.Setup(serv => serv.IsCustomerIdValid(customerId))
                .Returns(PropertyIsInValid);
            var controller = new CustomersController(_mockCustomerService.Object);

            //Act
            var result = await controller.GetById(customerId.ToString());
            var value = (result as BadRequestObjectResult).Value;

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(value, messageValue);
        }

        [Fact]
        public async Task Action_GetCustomerByValidEmail_ReturnsJsonResult_Code200AndData()
        {
            //Arrange
            var customerEmail = _email;
            int code200 = StatusCodes.Status200OK;
            _mockCustomerService.Setup(serv => serv.GetDataByEmailAsync(customerEmail))
                .ReturnsAsync(GetCustomer);
            _mockCustomerService.Setup(serv => serv.IsEmailValid(customerEmail))
                .Returns(PropertyIsValid);
            var controller = new CustomersController(_mockCustomerService.Object);

            //Act
            var result = await controller.GetByEmail(customerEmail);
            var code = (result as JsonResult).Value.GetType().GetProperty("StatusCode").GetValue((result as JsonResult).Value);

            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(code200, code);
        }


        [Fact]
        public async Task Action_GetCustomerByValidEmail_ReturnsNotFound()
        {
            //Arrange
            var customerEmail = _email;
            _mockCustomerService.Setup(serv => serv.IsEmailValid(customerEmail))
                .Returns(PropertyIsValid);
            _mockCustomerService.Setup(serv => serv.GetDataByEmailAsync(customerEmail))
                .ReturnsAsync((CustomerViewModel)null);
            var controller = new CustomersController(_mockCustomerService.Object);

            //Act
            var result = await controller.GetByEmail(customerEmail);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Action_GetCustomerByInValidEmail_ReturnsBadRequestAndMessage()
        {
            //Arrange
            var customerEmail = _email;
            var messageValue = "Invalid Email";
            _mockCustomerService.Setup(serv => serv.IsEmailValid(customerEmail))
                .Returns(PropertyIsInValid);
            var controller = new CustomersController(_mockCustomerService.Object);

            //Act
            var result = await controller.GetByEmail(customerEmail);
            var value = (result as BadRequestObjectResult).Value;

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(value, messageValue);
        }

        [Fact]
        public async Task Action_GetCustomerByIdAndEmail_ReturnsJsonResult_Code200AndData()
        {
            //Arrange
            var customerEmail = _email;
            var customerId = _customerId;
            int code200 = StatusCodes.Status200OK;
            _mockCustomerService.Setup(serv => serv.GetDataByIdAndEmailAsync(int.Parse(customerId), customerEmail))
                .ReturnsAsync(GetCustomer);
            _mockCustomerService.Setup(serv => serv.IsEmailValid(customerEmail))
                .Returns(PropertyIsValid);
            _mockCustomerService.Setup(serv => serv.IsCustomerIdValid(customerId))
                .Returns(PropertyIsValid);
            var controller = new CustomersController(_mockCustomerService.Object);

            //Act
            var result = await controller.GetByIdAndEmail(customerId, customerEmail);
            var code = (result as JsonResult).Value.GetType().GetProperty("StatusCode").GetValue((result as JsonResult).Value);

            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(code200, code);
        }

        [Fact]
        public async Task Action_GetCustomerByIdAndEmailWhenDoNotPassParameters_ReturnsBadRequestAndMessage()
        {
            //Arrange
            var customerEmail = "";
            var customerId = "";
            var messageValue = "No inquiry criteria";

            //_mockCustomerService.;

            var controller = new CustomersController(_mockCustomerService.Object);

            //Act
            var result = await controller.GetByIdAndEmail(customerId, customerEmail);
            var message = (result as BadRequestObjectResult).Value;

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(messageValue, message);
        }

        [Fact]
        public async Task Action_GetCustomerByValidIdAndEmail_ReturnsNotFound()
        {
            //Arrange
            var customerEmail = _email;
            var customerId = _customerId;
            _mockCustomerService.Setup(serv => serv.IsEmailValid(customerEmail))
                .Returns(PropertyIsValid);
            _mockCustomerService.Setup(serv => serv.IsCustomerIdValid(customerId))
                .Returns(PropertyIsValid);
            _mockCustomerService.Setup(serv => serv.GetDataByIdAndEmailAsync(int.Parse(customerId), customerEmail))
                .ReturnsAsync((CustomerViewModel)null);
            var controller = new CustomersController(_mockCustomerService.Object);

            //Act
            var result = await controller.GetByEmail(customerEmail);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }


        private CustomerViewModel GetCustomer()
        {
            return new CustomerViewModel
            {
                CustomerID = 1,
                Name = "John Doe",
                Email = _email,
                Mobile = "123456789",

                Transactions = new List<TransactionViewModel>()
                {
                    new TransactionViewModel
                    {
                        Id = 1,
                        Date = DateTime.Now.DateTimeTo_ddMMyyyy_hhmm(),
                        Amount = "228",
                        Currency = "USD",
                        Status = "Success"
                    }
                }
            };
        }

        private bool PropertyIsValid()
        {
            return true;
        }

        private bool PropertyIsInValid()
        {
            return false;
        }

    }
}

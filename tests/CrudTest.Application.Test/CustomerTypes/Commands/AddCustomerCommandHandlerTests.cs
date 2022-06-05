using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Handler;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.DTO;
using CleanArchitecture.Domain.Models;
using CrudTest.Application.Test.Mocks;
using Moq;
using Shouldly;

namespace CrudTest.Application.Test.CustomerTypes.Commands;
public class AddCustomerCommandHandlerTests
{
    private readonly Mock<ICustomerRepository> _mockRepo;
    private readonly CustomerDTO _customer;
    public AddCustomerCommandHandlerTests()
    {
        _mockRepo = MockCustomerRepository.GetCustomerRepository();

        _customer = new CustomerDTO
        {
            Firstname = "exampleName",
            Lastname = "AzaliexampleLName",
            PhoneNumber = "3214654155",
            Email = "Raminazali9@gmail.com",
            DateOfBirth = new DateTime(1998, 1, 12),
            BankAccountNumber = "5210-2345-6585-6773",
        };
    }


    [Fact]
    public async Task Customer_InsertHanlder_CorrectData()
    {
        var handler = new AddCustomerHandler(_mockRepo.Object);

        var result = await handler.Handle(new AddCustomerCommand(_customer) {}, CancellationToken.None);

        var Customers = await _mockRepo.Object.GetList();

        result.ShouldBeOfType<Customer>();

        Customers.Count.ShouldBe(4);
    }
}

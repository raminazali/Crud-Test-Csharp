using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Handler;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.DTO;
using CleanArchitecture.Domain.Exceptions;
using CrudTest.Application.Test.Mocks;
using Moq;
using Shouldly;

namespace CrudTest.Application.Test.Customer.Commands;
public class UpdateCustomerHandlerTests
{
    private readonly Mock<ICustomerRepository> _mockRepo;
    private readonly CleanArchitecture.Domain.Models.Customer _customer;
    private readonly UpdateCustomerHandler _handler;
    public UpdateCustomerHandlerTests()
    {
        _mockRepo = MockCustomerRepository.GetCustomerRepository();

        _handler = new UpdateCustomerHandler(_mockRepo.Object);

        _customer = new CleanArchitecture.Domain.Models.Customer
        {
            Id = 1,
            Firstname = "exampleName",
            Lastname = "AzaliexampleLName",
            PhoneNumber = "3214654155",
            Email = "Raminazali9@gmail.com",
            DateOfBirth = new DateTime(1998, 1, 12),
            BankAccountNumber = "5210-2345-6585-6773",
        };
    }
    // Because this Update Method Is Void Method And there is no Response i Can Just Check My Exception That may happens 

    [Theory]
    [InlineData("sakr21nbjnjnawsa")]
    public async Task Customer_Update_InvalidEmail(string InvalidEmail)
    {
        _customer.Email = InvalidEmail;
        NotValidEmail ex = await Should.ThrowAsync<NotValidEmail>(() => _handler.Handle(new UpdateCustomerCommand(_customer) { }, CancellationToken.None));
        var resultCount = await _mockRepo.Object.GetList();
        resultCount.Count.ShouldBe(3);
    }

    [Theory]
    [InlineData("1234568789")]
    public async Task Customer_Update_InvalidPhoneNumber(string PhoneNumber)
    {
        _customer.PhoneNumber = PhoneNumber;
        NotValidEmail ex = await Should.ThrowAsync<NotValidEmail>(() => _handler.Handle(new UpdateCustomerCommand(_customer) { }, CancellationToken.None));
        var resultCount = await _mockRepo.Object.GetList();
        resultCount.Count.ShouldBe(3);
    }

    [Theory]
    [InlineData("345435748641")]
    public async Task Customer_Update_InvalidBankAccountNumber(string BankAccountNumber)
    {
        _customer.BankAccountNumber = BankAccountNumber;
        NotValidEmail ex = await Should.ThrowAsync<NotValidEmail>(() => _handler.Handle(new UpdateCustomerCommand(_customer) { }, CancellationToken.None));
        var resultCount = await _mockRepo.Object.GetList();
        resultCount.Count.ShouldBe(3);
    }
}

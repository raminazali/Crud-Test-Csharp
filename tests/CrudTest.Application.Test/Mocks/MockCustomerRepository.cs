using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Models;
using Moq;

namespace CrudTest.Application.Test.Mocks;

public static class MockCustomerRepository
{
    public static Mock<ICustomerRepository> GetCustomerRepository()
    {
        var Customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Firstname = "Ramin",
                Lastname = "Azali",
                PhoneNumber = "3214654154",
                Email = "Raminazali8@gmail.com",
                DateOfBirth = new DateTime(1998,1,10),
                BankAccountNumber = "5210-2345-6585-9773",
            },
              new Customer
            {
                Id = 2,
                Firstname = "Saeed",
                Lastname = "Ahmadi",
                PhoneNumber = "3214654159",
                Email = "SaeedAhmadi@gmail.com",
                DateOfBirth = new DateTime(1995,1,10),
                BankAccountNumber = "5210-2345-6545-9773",
            },
                new Customer
            {
                Id = 3,
                Firstname = "Mason",
                Lastname = "Chase",
                PhoneNumber = "3214654157",
                Email = "MasonChase8@gmail.com",
                DateOfBirth = new DateTime(1990,1,10),
                BankAccountNumber = "5210-2445-6585-9873",
            },
        };

        var mockRepo = new Mock<ICustomerRepository>();

        mockRepo.Setup(r => r.GetList()).ReturnsAsync(Customers);
        mockRepo.Setup(r => r.AddAsync(It.IsAny<Customer>())).ReturnsAsync((Customer customer) =>
        {
            Customers.Add(customer);
            return customer;
        });

        return mockRepo;

    }
}
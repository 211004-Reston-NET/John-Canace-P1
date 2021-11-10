using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SFDL;
using SFModels;
using Xunit;

namespace SFTest
{
    public class RepositoryTest
    {
        private readonly DbContextOptions<_211004restonnetdemoContext> _options;
        public RepositoryTest()
        {
            _options = new DbContextOptionsBuilder<_211004restonnetdemoContext>()
                        .UseSqlite("Filename = Test.db").Options; //UseSqlite() method will create an inmemory database for use named Test.db
            Seed();
        }

        [Fact]
        public void GetAllCustomersShouldReturnAllCustomers()
        {
            using (var context = new _211004restonnetdemoContext(_options))
            {
                 //Arrange
                ICRepository repo = new RespositoryCloud(context);

                 //Act
                 List<Customer> test = repo.GetAllCustomers();

                 //Assert
                 Assert.Equal(2, test.Count);
                 Assert.Equal("Mick Rough", test[0].CustomerName);
            }
        }

        [Fact]
        public void AddCustomerShouldAddACustomer()
        {
            //First using block will add a restaruant
            using (var context = new _211004restonnetdemoContext(_options))
            {
                 //Arrange
                ICRepository repo = new RespositoryCloud(context);
                Customer addedCust = new Customer
                {
                    CustomerName = "Mick Rough",
                    CustomerAddress = "104 Dall Road",
                    CustomerEmail = "tyre@gmail.com",
                    CustomerPhoneNumber = "123-321-2345",
                    CustomerID = 09
                };

                 //Act
                 repo.AddCustomer(addedCust);
            }

            //Second using block will find that restaurant and see if it is similar to what we added
            //Assert
            using (_211004restonnetdemoContext contexts = new _211004restonnetdemoContext(_options))
            {
                Customer result = contexts.Customers.Find(3);

                Assert.NotNull(result);
                Assert.Equal("Mick Rough", result.CustomerName);
                Assert.Equal("104 Dall Road", result.CustomerAddress);
                Assert.Equal("tyre@gmail.com", result.CustomerEmail);
                Assert.Equal("123-321-2345", result.CustomerPhoneNumber);
                Assert.Equal(09, result.CustomerID);
            }
        }
        private void Seed()
        {
            //using block to automatically close the resource that is used to connect to this db after seeding data to it
            using (var context = new _211004restonnetdemoContext(_options))
            {
                //We want to make sure that our inmemory db gets deleted and recreated to not have any data from previous tests
                //We want a pristine database to ensure that every tests will have the exact same database being used to execute the test
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange
                (
                    new Customer
                    {
                        CustomerName = "Mick Rough",
                        CustomerAddress = "104 Dall Road",
                        CustomerEmail = "tyre@gmail.com",
                        CustomerPhoneNumber = "123-321-2345",
                        CustomerID = 09
                    },
                    new Customer
                    {
                        CustomerName = "Yoga Plum",
                        CustomerAddress = "234 Greatsy Lane",
                        CustomerEmail = "eradx@gmail.com",
                        CustomerPhoneNumber = "231-5873-2452",
                        CustomerID = 15
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
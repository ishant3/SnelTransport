using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Back_End;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace UnitTest_Back_End
{
    [TestClass]
    public class UnitTest_Back_End
    {
        [TestMethod]
        public void TestInsertCustomer(Customer cust)
        {
            
            //var Customer = new Customer
            //{
            //    Id = 1,
            //    Name = "BBB",
            //    Street = "dfsdf",
            //    HouseNumber = "sdsad",
            //    PostCode = "asdas",
            //    City = "asdasd",
            //    Telephone = "232",
            //    Fax = "234"
            //};

            //cust = Customer;

            //var mockContext = new Mock<EntitiesContext>();
            //var mockSet = new Mock<DbSet<Customer>>();  
        
            //mockContext.Setup(c => c.Customers).Returns(mockSet.Object);

            ////var service = new Service1();
            ////service.InsertCustomer(cust);

            //mockSet.Verify(m => m.Add(It.IsAny<Customer>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());


            //mockContext.Customers.Add(cust);
           // ec.SaveChanges();





        }
        

    }
}

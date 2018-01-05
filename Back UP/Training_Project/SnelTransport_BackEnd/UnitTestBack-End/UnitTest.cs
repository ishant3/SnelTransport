using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service_Database_Connection;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using FakeItEasy;

namespace UnitTestBack_End
{
    [TestClass]
    public class TestCustomer
    {

        
        [TestMethod]
        public void TestMethod1()
        {
            //var mockSet = new Mock<DbSet<Customer>>();

            //var mockContext = new Mock<EntitiesContext>();
            //mockContext.Setup(m => m.Customers).Returns(mockSet.Object);

            //var service = new Service1();
            ////service.AddBlog("ADO.NET Blog", "http://blogs.msdn.com/adonet");
            //service.InsertCustomer(Customer cust);
            //mockSet.Verify(m => m.Add(It.IsAny<Customer>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }
           

    }
}

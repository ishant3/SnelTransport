using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Back_End;

namespace UnitTest_Back_End
{
    [TestClass]
    public class UnitTest_Back_End
    {
        [TestMethod]
        public void TestInsertCustomer(Customer customer)
        {
           
           

            EntitiesContext ec = new EntitiesContext();
            //ec.Customers.Add(customer);
            //ec.SaveChanges();
            //Assert.AreEqual(expected, target.DoWork());
        }
    }
}

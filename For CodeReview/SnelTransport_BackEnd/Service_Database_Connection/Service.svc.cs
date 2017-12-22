using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service_Database_Connection
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService
    {
        #region Customer CRUD Operations................................................................

        public IEnumerable<Customer> GetCustomer()
        {
            List<Customer> customerList = new List<Customer>();
            EntitiesContext ec = new EntitiesContext();

            customerList = (from cust in ec.Customers
                            orderby cust.Id
                            select cust).Take(5).ToList();

            return customerList;

        }

        public void InsertCustomer(Customer customer)
        {
            EntitiesContext ec = new EntitiesContext();
            ec.Customers.Add(customer);
            ec.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            EntitiesContext ec = new EntitiesContext();
            var c = (from cust in ec.Customers
                     where cust.Id == customer.Id
                     select cust).First();
            c.Name = customer.Name;
            c.PostCode = customer.PostCode;
            c.HouseNumber = customer.HouseNumber;
            c.Street = customer.Street;
            c.Telephone = customer.Telephone;
            c.Fax = customer.Fax;
            c.City = customer.City;
            ec.SaveChanges();

        }

        public void DeleteCustomer(string id)
        {
            int k = Convert.ToInt32(id);
            EntitiesContext ec = new EntitiesContext();
            var c = (from cust in ec.Customers
                     where cust.Id == k
                     select cust).First();

            ec.Customers.Remove(c);
            ec.SaveChanges();

        }

        #endregion..........................................................


        #region Finding OptimalRoute CRUD ............................................................

        //for inserting distance from front-end json to database
        public void InsertDistanceInfo(List<Distance_Table> distance_info)
        {
            EntitiesContext ec = new EntitiesContext();
            ec.Distances.AddRange(distance_info);
            ec.SaveChanges();
        }       

          public void InsertOptimalRoute_Config(ConfigOptimalRoute configData)
        {
            EntitiesContext ec = new EntitiesContext();
            ec.OptimalRoute_Config.Add(configData);
            ec.SaveChanges();
        }
     

        public IEnumerable<Distance_Table> GetOptimalRoute()
        {
            OptimalRouteAlgorithm algorithm = new OptimalRouteAlgorithm();           
            List<Distance_Table> mytryoptimalRoute = new List<Distance_Table>();
            mytryoptimalRoute = algorithm.FindOptimalRoute();
            return mytryoptimalRoute;

        }        

      

        #endregion...................................................


        #region Article CRUD Operations..........................................................

        public void DeleteArticle(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetArticle()
        {
            throw new NotImplementedException();
        }

        public void InsertArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public void UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Order CRUD Operations.................................................................

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orders> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void InsertOrder(Orders order)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Orders order)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region OrderDetails CRUD Operations...........................................................

        public void InsertOrder_Detail(Order_Detail order_detail)
        {
            throw new NotImplementedException();
        }       

        public void UpdateOrder_Detail(Order_Detail order_detail)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder_Detail(int id)
        {
            throw new NotImplementedException();
        }      

        public IEnumerable<Order_Detail> GetOrders_Detail()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}

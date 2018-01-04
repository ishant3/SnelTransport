using Back_End.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Back_End
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
                            select cust).Skip(1).Take(7).ToList();

            if (customerList.Count()==0)
            {
                MyCustomErrorDetail customError = new MyCustomErrorDetail("Customers not found",
                 "No customer list exists in the database! Please check the Database First!");
                throw new WebFaultException<MyCustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }
            return customerList;

        }

        public void InsertCustomer(Customer customer)
        {
            if (customer != null)
            {
                EntitiesContext ec = new EntitiesContext();
                ec.Customers.Add(customer);
                ec.SaveChanges();
            }
            else {
                MyCustomErrorDetail customError = new MyCustomErrorDetail("Correct customer details not found",
                 "Please check all the customer fields entered are of correct type!");
                throw new WebFaultException<MyCustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer != null)
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
            else
            {
                MyCustomErrorDetail customError = new MyCustomErrorDetail("Correct customer details not provided",
                 "Please check all the customer fields entered are of correct type!");
                throw new WebFaultException<MyCustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }

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
            if (distance_info.Count() != 0)
            {
                EntitiesContext ec = new EntitiesContext();
                ec.Distances.AddRange(distance_info);
                ec.SaveChanges();
            }
            else
            {
                MyCustomErrorDetail customError = new MyCustomErrorDetail("Distance list not found",
               "Please check whether the list is successfully send!");
                throw new WebFaultException<MyCustomErrorDetail>(customError, HttpStatusCode.NotFound);

            }
        }

        public void InsertOptimalRoute_Config(ConfigOptimalRoute configData)
        {
            if (configData != null)
            {
                EntitiesContext ec = new EntitiesContext();
                ec.OptimalRoute_Config.Add(configData);
                ec.SaveChanges();
            }
            else
            {
                MyCustomErrorDetail customError = new MyCustomErrorDetail("Optimal Route Configuration not found",
               "Please check wheteher config properties with proper input type is provided!");
                throw new WebFaultException<MyCustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }
        }


        public IEnumerable<Distance_Table> GetOptimalRoute()
        {
            OptimalRouteAlgorithm algorithm = new OptimalRouteAlgorithm();
            List<Distance_Table> mytryoptimalRoute = new List<Distance_Table>();
            mytryoptimalRoute = algorithm.FindOptimalRoute();
            return mytryoptimalRoute;

        }

        public IEnumerable<ConfigOptimalRoute> GetOptimalRoute_Config()
        {
            List<ConfigOptimalRoute> configData = new List<ConfigOptimalRoute>();
            EntitiesContext ec = new EntitiesContext();

            configData = (from cust in ec.OptimalRoute_Config
                          orderby cust.Unload_Time
                          select cust).ToList();
            if (configData.Count==0)
            {
                MyCustomErrorDetail customError = new MyCustomErrorDetail("Configuration data not found",
                    "No configuration properties  list exists in the database! Please check the Database First!");
                throw new WebFaultException<MyCustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }

            return configData;
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

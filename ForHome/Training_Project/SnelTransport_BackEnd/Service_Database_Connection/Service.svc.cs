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
        public void DeleteArticle(int id)
        {
            throw new NotImplementedException();
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

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder_Detail(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetArticle()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomer()
        {
            List<Customer> customerList = new List<Customer>();
            EntitiesContext ec = new EntitiesContext();
            
           // customerList= ec.Customers.ToList();

             customerList = (from cust in ec.Customers                       
                         orderby cust.Id
                         select cust).Take(5).ToList();
            
            return customerList;

        }

        public IEnumerable<Orders> GetOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order_Detail> GetOrders_Detail()
        {
            throw new NotImplementedException();
        }

        public void InsertArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public void InsertCustomer(Customer customer)
        {
            EntitiesContext ec = new EntitiesContext();
            ec.Customers.Add(customer);
            ec.SaveChanges();
        }

        public void InsertOrder(Orders order)
        {
            throw new NotImplementedException();
        }

        public void InsertOrder_Detail(Order_Detail order_detail)
        {
            throw new NotImplementedException();
        }

        public void UpdateArticle(Article article)
        {
            throw new NotImplementedException();
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

        public void UpdateOrder(Orders order)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder_Detail(Order_Detail order_detail)
        {
            throw new NotImplementedException();
        }

        //for iserting distance for front-end json to database
        public void InsertDistanceInfo(List<Distance_Table> distance_info)
        {
            EntitiesContext ec = new EntitiesContext();   
            ec.Distances.AddRange(distance_info);
            ec.SaveChanges();
        }

        public IEnumerable<Distance_Table> GetOptimalRoute()
        {
            List<Distance_Table> orinialList = new List<Distance_Table>();
            EntitiesContext ec = new EntitiesContext();         

            orinialList = (from cust in ec.Distances
                            orderby cust.Id
                            select cust).ToList();

            List<Distance_Table> optimalRoute = new List<Distance_Table>();
            List<Distance_Table> address = new List<Distance_Table>();
            List<Distance_Table> temp_Address = new List<Distance_Table>();
            List<Distance_Table> Total_Address = new List<Distance_Table>();

            Total_Address = orinialList.GroupBy(x=>x.Origin).Select( p => p.First()).Distinct().ToList();
            temp_Address = orinialList.Where(p => p.Origin != p.Destination).ToList();

            int total_time = 30;
            int allowed_time=480;
            int fake_time = 0;

            address = temp_Address.Where(p => p.Origin.Contains("Zeugstraat 92, 2801 JD Gouda, Netherlands")).OrderBy(c => c.Duration).Take(1).ToList();
            total_time =total_time+ address[0].Duration+30;
            fake_time = total_time;
            temp_Address = temp_Address.Where(p => p.Destination != address[0].Origin).OrderBy(c => c.Duration).ToList();
                       
            address = orinialList.Where(p => p.Origin.Contains(address[0].Destination) && p.Destination.Contains("Zeugstraat 92, 2801 JD Gouda, Netherlands")).Take(1).ToList();
            fake_time = total_time + address[0].Duration;
            
            if (fake_time <= allowed_time)
            {                
                    int i = 1;
                    while (i <= Total_Address.Count - 2)
                    {
                      
                        address = temp_Address.Where(p => p.Origin.Contains(address[0].Destination)).OrderBy(c => c.Duration).Take(1).ToList();
                        total_time = total_time + address[0].Duration + 30;

                    if (total_time <= allowed_time)
                    {
                        optimalRoute.AddRange(address);
                        temp_Address = temp_Address.Where(p => p.Destination != address[0].Origin).OrderBy(c => c.Duration).ToList();
                    }
                    else
                    {
                        address = orinialList.Where(p => p.Origin.Contains(address[0].Destination) && p.Destination.Contains("Zeugstraat 92, 2801 JD Gouda, Netherlands")).Take(1).ToList();
                        total_time = total_time + address[0].Duration;
                        optimalRoute.AddRange(address);
                    }
                        i++;
                      }         
            }

            address = orinialList.Where(p => p.Origin.Contains(address[0].Destination) && p.Destination.Contains("Zeugstraat 92, 2801 JD Gouda, Netherlands")).Take(1).ToList();
            total_time = total_time + address[0].Duration;
            optimalRoute.AddRange(address);
            

            return optimalRoute;



;


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service_Database_Connection
{
    [ServiceContract]
    public interface IService
    {
        // For Customer....................
        [OperationContract]
        [WebInvoke(Method ="GET",ResponseFormat =WebMessageFormat.Json,UriTemplate ="GetCustomer")]
        IEnumerable<Customer> GetCustomer();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "InsertCustomer")]
        void InsertCustomer(Customer customer);
      
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "UpdateCustomer")]
        void UpdateCustomer(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle =WebMessageBodyStyle.Wrapped, RequestFormat= WebMessageFormat.Json, UriTemplate = "DeleteCustomer/{id}")]
        void DeleteCustomer(string id);


        //For Optimal Route..............       
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "InsertDistance_Data")]
        void InsertDistanceInfo(List<Distance_Table> distance_info);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetOptimal")]
         IEnumerable<Distance_Table> GetOptimalRoute();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "Post_Config_Optimal_Route")]
        void InsertOptimalRoute_Config(ConfigOptimalRoute configData);


        // For Article....................
        [OperationContract]
        IEnumerable<Article> GetArticle();
        [OperationContract]
        void InsertArticle(Article article);
        [OperationContract]
        void UpdateArticle(Article article);
        [OperationContract]
        void DeleteArticle(int id);

        // For Order....................
        [OperationContract]
        IEnumerable<Orders> GetOrders();
        [OperationContract]
        void InsertOrder(Orders order);
        [OperationContract]
        void UpdateOrder(Orders order);
        [OperationContract]
        void DeleteOrder(int id);

        // For OrderDetails....................
        [OperationContract]
        IEnumerable<Order_Detail> GetOrders_Detail();
        [OperationContract]
        void InsertOrder_Detail(Order_Detail order_detail);
        [OperationContract]
        void UpdateOrder_Detail(Order_Detail order_detail);
        [OperationContract]
        void DeleteOrder_Detail(int id);
        
    }
}

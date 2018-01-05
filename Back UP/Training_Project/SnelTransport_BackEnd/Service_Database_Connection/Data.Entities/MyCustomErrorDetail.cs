using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Service_Database_Connection.Data.Entities
{
    [DataContract]
    public class MyCustomErrorDetail
    {
        public MyCustomErrorDetail(string errorInfo, string errorDetails)
        {
            ErrorInfo = errorInfo;
            ErrorDetails = errorDetails;
        }

        [DataMember]
        public string ErrorInfo { get; private set; }

        [DataMember]
        public string ErrorDetails { get; private set; }
    }
}
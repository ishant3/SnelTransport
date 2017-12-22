using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service_Database_Connection
{
    [DataContract]
    [Table("Orders", Schema = "public")]
    public class Orders
    {
        [DataMember]
        [Column("order_id")]
        [Key]
        [Required]
        public int Id { get; set; }


        [DataMember]
        [Column("order_date_time")]
        [Required]
        public DateTime dateTime { get; set; }


        [DataMember]
        [Column("order_received")]
        [Required]
        public bool Revceived { get; set; }


        [DataMember]
        [Column("order_delivered")]
        [Required]
        public bool Delivered { get; set; }


        [DataMember]
        [Column("order_type")]
        [Required]
        public OrderType orderType { get; set; }


        [DataMember]
        [Column("customer_id")]        
        [Required]
        public int CustomerId { get; set; }
        
        [DataMember]
        public virtual Customer Customer { get; set; }


        [DataMember]
        [Column("orders_details")]
        [Required]
        public virtual ICollection<Order_Detail> OrderDetails { get; set; }
       

        public Orders()
        {
            OrderDetails = new List<Order_Detail>();
        }

    }
}
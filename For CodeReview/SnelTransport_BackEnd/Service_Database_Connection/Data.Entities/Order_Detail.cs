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
    [Table("Order_detail", Schema = "public")]
    public class Order_Detail
    {
        [DataMember]
        [Column("order_detail_id")]
        [Key]
        [Required]
        public int Id { get; set; }


        [DataMember]
        [Column("quantity")]
        [Required]
        public int Quantity { get; set; }


        [DataMember]
        [Column("order_order_id")]
        [Required]
        public int OrderId { get; set; }
        [DataMember]      
        public virtual Orders Order { get; set; }


        [DataMember]
        [Column("article_article_id")]        
        [Required]        
        public int ArticleId { get; set; }
        [DataMember]
        public virtual Article Article { get; set; }



    }
}
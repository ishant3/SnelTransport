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
    [Table("Article", Schema = "public")]
    public class Article
    {
        [DataMember]
        [Column("article_id")]
        [Key]
        [Required]
        public int Id { get; set; }


        [DataMember]
        [Column("article_name")]
        [Required]
        public string Name { get; set; }


        [DataMember]
        [Column("article_color")]
        [Required]
        public ColorType Color { get; set; }


        [DataMember]
        [Column("article_price")]
        [Required]
        public double Price { get; set; }


        [DataMember]
        [Column("articleType")]
        [Required]
        public string Type { get; set; }

    }
}
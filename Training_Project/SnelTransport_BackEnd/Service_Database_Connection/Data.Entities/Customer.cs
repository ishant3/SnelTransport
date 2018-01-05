using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Service_Database_Connection
{
    [DataContract]
    [Table("Customer",Schema="public") ]
    public class Customer
    {
        [DataMember]
        [Column("customer_id")]
        [Key]
        [Required]
        public int Id { get; set; }


        [DataMember]
        [Column("customer_name")]
        [Required]
        public string Name { get; set; }


        [DataMember]
        [Column("customer_street")]
        [Required]
        public string Street { get; set; }


        [DataMember]
        [Column("customer_housenumber")]
        [Required]
        public string HouseNumber { get; set; }


        [DataMember]
        [Column("customer_postcode")]
        [Required]
        public string PostCode { get; set; }


        [DataMember]
        [Column("customer_city")]
        [Required]
        public string City { get; set; }


        [DataMember]
        [Column("customer_tel_number")]
        [Required]
        public string Telephone { get; set; }


        [DataMember]
        [Column("customer_fax_number")]
        public string Fax { get; set; }
    }
}
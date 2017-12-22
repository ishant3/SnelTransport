using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Service_Database_Connection
{

    [DataContract]
    [Table("ConfigOptimalRoute", Schema = "public")]
    public class ConfigOptimalRoute
    {      
        [DataMember]
        [Column("Name")]
        [Key]
        [Required]
        public string Name { get; set; }
        
        [DataMember]
        [Column("Maximum_Hour")]
        [Required]
        public int Maximum_Hour { get; set; }
        
        [DataMember]
        [Column("Unload_Time")]
        [Required]
        public decimal Unload_Time { get; set; }


    }
}
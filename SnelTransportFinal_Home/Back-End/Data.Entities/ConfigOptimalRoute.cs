using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace Back_End
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

        [DataMember]
        [Column("Truck_Number")]
        [Required]
        public int Truck_Number { get; set; }




    }
}
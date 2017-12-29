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
    [Table("Distance_Table", Schema = "public")]
    public class Distance_Table
    {

        [DataMember]
        [Column("ID")]
        [Key]
        public int Id { get; set; }


        [DataMember]
        [Column("FROM")]
        [Required]
        public string Origin { get; set; }


        [DataMember]
        [Column("TO")]
        [Required]
        public string Destination { get; set; }


        [DataMember]
        [Column("DISTANCE")]
       [Required]
        public int Distance { get; set; }


        [DataMember]
        [Column("DURATION")]
        [Required]
        public int Duration { get; set; }

    }
}
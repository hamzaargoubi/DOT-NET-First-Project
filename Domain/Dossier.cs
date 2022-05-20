using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Dossier
    {
        [DataType(DataType.Date)]
        public DateTime DateDepot { get; set; }
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        public Double Frais { get; set; }
        public Boolean Clos { get; set; }
        [ForeignKey("Client")]
        public int  ClientFK { get; set; }
        [ForeignKey("Avocat")]
        public int  AvocatFK { get; set; }
       // [ForeignKey("ClientFK")]
        public virtual Client Client { get; set; }
       // [ForeignKey("AvocatFK")]
        public virtual Avocat Avocat { get; set; }



    }
}
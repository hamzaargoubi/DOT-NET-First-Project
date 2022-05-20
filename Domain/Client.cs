using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Client
    {
        [Key]
        public int CIN { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public virtual IList<Dossier> Dossiers { get; set; }
    }
}

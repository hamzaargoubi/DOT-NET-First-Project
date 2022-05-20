using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Avocat
    {
        public int AvocatId { get; set; }
        [Required(ErrorMessage ="le nom doit etre saisie")]
        public String Nom { get; set; }
        [Required(ErrorMessage = "le prenom doit etre saisie")]

        public String Prenom { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateEmbauche { get; set; }
        public virtual IList<Dossier> Dossiers { get; set; }
        
        public int? SpecialiteFK { get; set; }
        public virtual Specialite Specialite { get; set; }
        
    }
}
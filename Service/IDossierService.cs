using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
  public   interface IDossierService:IService<Dossier>
    {
        public IList<Client> GetClientsByAvocat(Avocat avocat);
        public int GetNumberDossierBySpecialite(Dossier dossier);
        public void Reduction(Dossier dossier);

    }
}

using Domain;
using PS.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
   public  class DossierService:Service<Dossier>,IDossierService
    {
        public DossierService(IUnitOfWork iunitOfWork):base(iunitOfWork)
        {
                
        }

        public IList<Client> GetClientsByAvocat(Avocat avocat)
        {
            return GetMany(D => D.AvocatFK == avocat.AvocatId).Where(D => (DateTime.Now - D.DateDepot).TotalDays <= 10).Select(D => D.Client).ToList();
        }
        public int GetNumberDossierBySpecialite(Dossier dossier)
        {
            return GetMany(D => D.Avocat.SpecialiteFK == dossier.Avocat.SpecialiteFK).Count();
        }
        public void Reduction(Dossier dossier)
        {
            var number=
            GetMany(D => D.Client == dossier.Client && D.AvocatFK == dossier.AvocatFK && D.Clos == true).Count();
            if (number > 3)
            {
               dossier.Frais = dossier.Frais * 0.7;
                Update(dossier);
                Commit();
            }
        }
    }
}

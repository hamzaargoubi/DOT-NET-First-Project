using Domain;
using PS.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
   public class ServiceSpecialite:Service<Specialite>,ISpecialiteService
    {
        public ServiceSpecialite(IUnitOfWork iunitOfWork) : base(iunitOfWork)
        {
                
        }
        public Specialite GetSpecialiteByAvocat()
        {
            return GetMany().OrderByDescending(S => S.Avocats.Count).FirstOrDefault();
        }
        public int GetNumberDossierBySpecialite(Dossier dossier)
        {
            return  Get(S=>S.Id==dossier.Avocat.SpecialiteFK).Avocats.SelectMany(A=>A.Dossiers).Count();
        }
    }
}

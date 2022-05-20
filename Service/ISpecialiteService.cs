using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
  public interface ISpecialiteService:IService<Specialite>
    {
        public Specialite GetSpecialiteByAvocat();
        public int GetNumberDossierBySpecialite(Dossier dossier);
       
    }
}

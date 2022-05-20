using Domain;
using PS.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
   public  class ClientService:Service<Client>,IClientService
    {
        public ClientService(IUnitOfWork iunitOfWork) : base(iunitOfWork)
        {
                
        }
        public IList<Client> GetClientsByAvocat(Avocat avocat)
        {
            return GetMany().SelectMany(c => c.Dossiers).Where(c =>( c.AvocatFK == avocat.AvocatId) && (DateTime.Now - c.DateDepot ).TotalDays <  10).Select(c=>c.Client).ToList();
        }
    }
}

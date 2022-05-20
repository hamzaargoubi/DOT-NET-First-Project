using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
   public  interface IClientService:IService<Client>
    {
        public IList<Client> GetClientsByAvocat(Avocat avocat);
    }
}

using Domain;
using PS.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
   public  class AvoactService:Service<Avocat>,IServiceAvocat
    {
        public AvoactService(IUnitOfWork iunitOfWork) : base(iunitOfWork)
        {

        }
    }
}

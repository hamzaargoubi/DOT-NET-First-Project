using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.Data.Infrastructure;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class DossierController : Controller
    {
       // IUnitOfWork unitOfWork;
        //DataBaseFactory DataBaseFactory;
        IDossierService dossierService;
        IClientService clientService;
        IServiceAvocat serviceAvocat;

        /* public DossierController()
         {
             DataBaseFactory = new DataBaseFactory();
             this.unitOfWork = new UnitOfWork(this.DataBaseFactory);

             this.dossierService =new DossierService(this.unitOfWork);
             this.clientService = new ClientService(this.unitOfWork);
             this.serviceAvocat = new AvoactService(this.unitOfWork);

         }
        */
        // GET: DossierController
        public DossierController(IDossierService dossierService, IServiceAvocat serviceAvocat, IClientService clientService)
        {
            this.serviceAvocat = serviceAvocat;
            this.clientService = clientService;
            this.dossierService = dossierService;
        }
        public ActionResult Index( string search )
        {
            if(string.IsNullOrEmpty (search))
            {
                return View(dossierService.GetMany().ToList());
            }
            else
            {
                return View(dossierService.GetMany(D=>D.Avocat.Nom.Contains(search)).ToList());
            }
            

        }

        // GET: DossierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DossierController/Create
        public ActionResult Create()
        {
            ViewBag.ClientFK = new SelectList(clientService.GetMany().ToList(), "CIN", "Nom");
            ViewBag.AvocatFK = new SelectList(serviceAvocat.GetMany().ToList(), "AvocatId", "Nom");
            return View();
        }

        // POST: DossierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dossier dossier)
        {
            try
            {
                dossierService.Add(dossier);
                dossierService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DossierController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DossierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DossierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DossierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

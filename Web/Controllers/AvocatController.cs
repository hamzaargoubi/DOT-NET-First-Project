﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Data.Infrastructure;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{

    public class AvocatController : Controller
    {
        //IUnitOfWork unitOfWork;
       // DataBaseFactory DataBaseFactory;
        IServiceAvocat serviceAvocat;

        /* public AvocatController()
         {
             DataBaseFactory = new DataBaseFactory();
             this.unitOfWork = new UnitOfWork(this.DataBaseFactory);


             this.serviceAvocat = new AvoactService(this.unitOfWork);

         }*/
        // GET: AvocatController
        public AvocatController(IServiceAvocat serviceAvocat)
        {
            this.serviceAvocat = serviceAvocat;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: AvocatController/Details/5
        public ActionResult Details(int id)
        {
            return View(serviceAvocat.GetById(id));
        }

        // GET: AvocatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvocatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AvocatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AvocatController/Edit/5
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

        // GET: AvocatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AvocatController/Delete/5
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

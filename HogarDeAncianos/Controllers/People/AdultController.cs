using HogarDeAncianos.Bussiness.Entities;
using HogarDeAncianos.DataAccess.Repositories.People;
using HogarDeAncianos.Models;
using HogarDeAncianos.ParametersObjects.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HogarDeAncianos.Controllers.People
{
    public class AdultController : Controller
    {
        private AdultRepository adults = new AdultRepository();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<Adult> adultList = await adults.GetManyDocumentsAsync();
            List<AdultViewModel> vista = new List<AdultViewModel>();


            foreach (var adult in adultList)
            {
                AdultViewModel model = new AdultViewModel
                {
                    Address = adult.Address,
                    Age = adult.Age,
                    Biomechamical = adult.Biomechamical,
                    BirthDate = adult.BirthDate,
                    CivilStatus = adult.CivilStatus,
                    Contribution = adult.Contribution,
                    CreatedByUser = adult.CreatedByUser,
                    CreationTime = adult.CreationTime,
                    EditedByUser = adult.EditedByUser,
                    EditionTime = adult.EditionTime,
                    EntryReasons = adult.EntryReasons,
                    EntryDate = adult.EntryDate,
                    FirstSurname = adult.FirstSurname,
                    Gender = adult.Gender,
                    Identification = adult.Identification,
                    IdCCSS = adult.IdCCSS,
                    Name = adult.Name,
                    Occupation = adult.Occupation,
                    Pension = adult.Pension,
                    SecondSurname = adult.SecondSurname,
                    State = adult.State,
                    Total = adult.Total
                };

                vista.Add(model);
            }

            return View(vista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AdultViewModel modelo)
        {
            if (ModelState.IsValid)
            {

                AdultParameter adultParameter = modelo;
                Adult employee = new Adult(adultParameter);
                adults.CreateOneDocument(employee);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Algunos de los campos requeridos no esta presente");
                return View(modelo);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(string id)
        {
            Adult adult = await adults.GetOneDocument(id);
            if (adult != null)
            {
                AdultViewModel model = new AdultViewModel
                {
                    Address = adult.Address,
                    Age = adult.Age,
                    Biomechamical = adult.Biomechamical,
                    BirthDate = adult.BirthDate,
                    CivilStatus = adult.CivilStatus,
                    Contribution = adult.Contribution,
                    CreatedByUser = adult.CreatedByUser,
                    CreationTime = adult.CreationTime,
                    EditedByUser = adult.EditedByUser,
                    EditionTime = adult.EditionTime,
                    EntryReasons = adult.EntryReasons,
                    EntryDate = adult.EntryDate,
                    FirstSurname = adult.FirstSurname,
                    Gender = adult.Gender,
                    Identification = adult.Identification,
                    IdCCSS = adult.IdCCSS,
                    Name = adult.Name,
                    Occupation = adult.Occupation,
                    Pension = adult.Pension,
                    SecondSurname = adult.SecondSurname,
                    State = adult.State,
                    Total = adult.Total
                };

                return View(model);
            }
            else
            {
                ViewBag.ErrirMessage = "El id de ensayo ingresado no fue encontrado";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            adults.DeleteOneDocument(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            Adult adult = await adults.GetOneDocument(id);
            AdultViewModel model = new AdultViewModel
            {
                Address = adult.Address,
                Age = adult.Age,
                Biomechamical = adult.Biomechamical,
                BirthDate = adult.BirthDate,
                CivilStatus = adult.CivilStatus,
                Contribution = adult.Contribution,
                CreatedByUser = adult.CreatedByUser,
                CreationTime = adult.CreationTime,
                EditedByUser = adult.EditedByUser,
                EditionTime = adult.EditionTime,
                EntryReasons = adult.EntryReasons,
                EntryDate = adult.EntryDate,
                FirstSurname = adult.FirstSurname,
                Gender = adult.Gender,
                Identification = adult.Identification,
                IdCCSS = adult.IdCCSS,
                Name = adult.Name,
                Occupation = adult.Occupation,
                Pension = adult.Pension,
                SecondSurname = adult.SecondSurname,
                State = adult.State,
                Total = adult.Total
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(string id, AdultViewModel modelo)
        {
            {
                if (ModelState.IsValid)
                {

                    AdultParameter adult = modelo;
                    Adult employee = new Adult(adult);
                    adults.UpdateOneDument(id, employee);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Algunos de los campos requeridos no esta presente");
                    return View(modelo);
                }
            }
        }
    }
}
using HogarDeAncianos.Bussiness.Entities.Records;
using HogarDeAncianos.DataAccess.Repositories.Records;
using HogarDeAncianos.Models;
using HogarDeAncianos.ParametersObjects.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HogarDeAncianos.Controllers
{
    public class PsychologicalController : Controller
    {

        private PsychologicalRepository records = new PsychologicalRepository();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<Psychological> recordsIEnumerable = await records.GetManyDocumentsAsync();
            List<PsychologicalViewModel> vista = new List<PsychologicalViewModel>();


            foreach (var record in recordsIEnumerable)
            {
                PsychologicalViewModel model = new PsychologicalViewModel
                {
                    Identification = record.Identification,
                    MentalTest = record.MentalTest,
                    PersonalHistory = record.PersonalHistory,
                    Monitoring = record.Monitoring,
                    PsychologicalTest = record.PsychologicalTest,
                    Observations = record.Observations,
                    CreatedByUser = record.CreatedByUser,
                    EditedByUser = record.EditedByUser,
                    CreationTime = record.CreationTime,
                    EditionTime = record.EditionTime
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
        public ActionResult Create(PsychologicalViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                PsychologicalParameter record = modelo;
                Psychological newRecord = new Psychological(record);
                records.CreateOneDocument(newRecord);
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
            Psychological record = await records.GetOneDocument(id);
            if (record != null)
            {
                PsychologicalViewModel model = new PsychologicalViewModel
                {
                    Identification = record.Identification,
                    MentalTest = record.MentalTest,
                    PersonalHistory = record.PersonalHistory,
                    Monitoring = record.Monitoring,
                    PsychologicalTest = record.PsychologicalTest,
                    Observations = record.Observations,
                    CreatedByUser = record.CreatedByUser,
                    EditedByUser = record.EditedByUser,
                    CreationTime = record.CreationTime,
                    EditionTime = record.EditionTime
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
            if (records.DeleteOneDocument(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrirMessage = "No se puede eliminar el expediente";
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            Psychological record = await records.GetOneDocument(id);
            PsychologicalViewModel model = new PsychologicalViewModel
            {
                Identification = record.Identification,
                MentalTest = record.MentalTest,
                PersonalHistory = record.PersonalHistory,
                Monitoring = record.Monitoring,
                PsychologicalTest = record.PsychologicalTest,
                Observations = record.Observations,
                CreatedByUser = record.CreatedByUser,
                EditedByUser = record.EditedByUser,
                CreationTime = record.CreationTime,
                EditionTime = record.EditionTime
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(string id, PsychologicalViewModel modelo)
        {
            {
                if (ModelState.IsValid)
                {

                    PsychologicalParameter record = modelo;
                    Psychological employee = new Psychological(record);
                    records.UpdateOneDument(id, employee);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Algunos de los campos requeridos no esta presente");
                    return View(modelo);
                }
            }

            return RedirectToAction("Index");
        }

    }
}
using HogarDeAncianos.Bussiness.Entities.Records;
using HogarDeAncianos.DataAccess.Repositories.People;
using HogarDeAncianos.Models;
using HogarDeAncianos.ParametersObjects.People;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HogarDeAncianos.Controllers.People
{
    public class RelativeController : Controller
    {
        private RelativeRepository relatives = new RelativeRepository();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<Relative> relativesList = await relatives.GetManyDocumentsAsync();
            List<RelativeViewModel> vista = new List<RelativeViewModel>();


            foreach (var relative in relativesList)
            {
                RelativeViewModel model = new RelativeViewModel
                {
                    Identification = relative.Identification,
                    Name = relative.Name,
                    FirstSurname = relative.FirstSurname,
                    SecondSurname = relative.SecondSurname,
                    Address = relative.Address,
                    Related = relative.Related,
                    Phone = relative.Phone,
                    OlderAdultId = relative.OlderAdultId,
                    Email = relative.Email
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
        public ActionResult Create(RelativeViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                RelativeParameter newRelative = modelo;
                Relative employee = new Relative(newRelative);
                relatives.CreateOneDocument(employee);
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
            Relative relative = await relatives.GetOneDocument(id);
            if (relative != null)
            {
                RelativeViewModel model = new RelativeViewModel
                {
                    Identification = relative.Identification,
                    Name = relative.Name,
                    FirstSurname = relative.FirstSurname,
                    SecondSurname = relative.SecondSurname,
                    Address = relative.Address,
                    Related = relative.Related,
                    Phone = relative.Phone,
                    OlderAdultId = relative.OlderAdultId,
                    Email = relative.Email
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
            relatives.DeleteOneDocument(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            Relative relative = await relatives.GetOneDocument(id);
            RelativeViewModel model = new RelativeViewModel
            {
                Identification = relative.Identification,
                Name = relative.Name,
                FirstSurname = relative.FirstSurname,
                SecondSurname = relative.SecondSurname,
                Address = relative.Address,
                Related = relative.Related,
                Phone = relative.Phone,
                OlderAdultId = relative.OlderAdultId,
                Email = relative.Email
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(string id, RelativeViewModel modelo)
        {
            {
                if (ModelState.IsValid)
                {
                    RelativeParameter relative = modelo;
                    Relative employee = new Relative(relative);
                    relatives.UpdateOneDument(id, employee);
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
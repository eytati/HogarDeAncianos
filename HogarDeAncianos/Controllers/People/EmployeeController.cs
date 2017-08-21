using HogarDeAncianos.Bussiness.Entities;
using HogarDeAncianos.DataAccess.Repositories.People;
using HogarDeAncianos.Models;
using HogarDeAncianos.ParametersObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HogarDeAncianos.Controllers.People
{
    public class EmployeeController : Controller
    {

        private EmployeeRepository empleados = new EmployeeRepository();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<Employee> employees = await empleados.GetManyDocumentsAsync();
            List<EmployeeViewModel> vista = new List<EmployeeViewModel>();

            
            foreach (var employee in employees)
            {
                EmployeeViewModel model = new EmployeeViewModel
                {
                    Email = employee.Email,
                    EntryDate = employee.EntryDate,
                    Identification = employee.Identification,
                    LastName = employee.Lastname,
                    Name = employee.Name,
                    Occupation = employee.Occupation,
                    Phone= employee.Phone,
                    State = employee.State
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
        public ActionResult Create(EmployeeViewModel modelo)
        {
            if (ModelState.IsValid)
            {

                EmployeeParameter employ = modelo;
                Employee employee = new Employee(employ);
                empleados.CreateOneDocument(employee);
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
            Employee employee = await empleados.GetOneDocument(id);
            EmployeeViewModel model = new EmployeeViewModel
            {
                Email = employee.Email,
                EntryDate = employee.EntryDate,
                Identification = employee.Identification,
                LastName = employee.Lastname,
                Name = employee.Name,
                Occupation = employee.Occupation,
                Phone = employee.Phone,
                State = employee.State
            };

            return View(model);



            //EmpleadoAbs empleado = new EmpleadoModeloConcreto(empleados, id);
            //if (empleado.Load())
            //{
                
            //}
            //else
            //{
            //    ViewBag.ErrirMessage = "El id de ensayo ingresado no fue encontrado";
            //    return View("Error");
            //}
        }

        [HttpGet]
    public ActionResult Delete(string id)
    {
            empleados.DeleteOneDocument(id);
            return RedirectToAction("Index");
     }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            Employee employee = await empleados.GetOneDocument(id);
            EmployeeViewModel model = new EmployeeViewModel
            {
                Email = employee.Email,
                EntryDate = employee.EntryDate,
                Identification = employee.Identification,
                LastName = employee.Lastname,
                Name = employee.Name,
                Occupation = employee.Occupation,
                Phone = employee.Phone,
                State = employee.State
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(string id, EmployeeViewModel modelo)
        {
            {
                if (ModelState.IsValid)
                {

                    EmployeeParameter employ = modelo;
                    Employee employee = new Employee(employ);
                    empleados.UpdateOneDument(id, employee);
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

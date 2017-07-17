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
                    Phone= employee.Occupation,
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

            //[HttpGet]
            //public ActionResult Detalles(string id)
            //{
            //    EmpleadoAbs empleado = new EmpleadoModeloConcreto(empleados, id);
            //    if (empleado.Load())
            //    {
            //        return View(empleado);
            //    }
            //    else
            //    {
            //        ViewBag.ErrirMessage = "El id de ensayo ingresado no fue encontrado";
            //        return View("Error");
            //    }
            //}

     [HttpGet]
    public ActionResult Eliminar(string id)
    {
            empleados.DeleteOneDocument(id);
            return RedirectToAction("Index");
     }

            //[HttpGet]
            //public ActionResult Editar(string id)
            //{
            //    EmpleadoAbs empleado = empleados.Read(empleadito => empleadito.Cedula_Empleado == id).SingleOrDefault();
            //    Empleados modelo = new Empleados
            //    {
            //        Cedula = empleado.Cedula,
            //        Nombre = empleado.Nombre,
            //        PrimerApellido = empleado.PrimerApellido,
            //        SegundoApellido = empleado.SegundoApellido,
            //        Direccion = empleado.Direccion,
            //        Puesto = empleado.Puesto,
            //        Correo = empleado.Correo,
            //        Telefono = empleado.Telefono,
            //        Estado = empleado.Estado
            //    };
            //    return View(modelo);
            //}

            //[HttpPost]
            //public ActionResult Editar(Empleados modelo)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        EmpleadoAbs empleado = new EmpleadoModeloConcreto(modelo, empleados);
            //        empleado.Update();
            //    }

            //    else
            //    {
            //        ModelState.AddModelError("", "Algunos de los campos requeridos no esta presente");
            //    }
            //    return RedirectToAction("Index");
            //}
            //}
        }
}
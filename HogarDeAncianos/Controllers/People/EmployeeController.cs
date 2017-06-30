using HogarDeAncianos.Bussiness.Entities;
using HogarDeAncianos.DataAccess.Repositories.People;
using HogarDeAncianos.Models;
using HogarDeAncianos.ParametersObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HogarDeAncianos.Controllers.People
{
    public class EmployeeController : Controller
    {

        private EmployeeRepository empleados = new EmployeeRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View(empleados.GetManyDocuments());
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Crear(EmployeeViewModel modelo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employee employ = null;
        //        empleados.CreateOneDocument(employ);
        //      //  EmpleadoAbs empleado = new EmpleadoModeloConcreto(modelo, empleados);
        //       // empleado.Save();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Algunos de los campos requeridos no esta presente");
        //        return View(modelo);
        //    }
        //}

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

        //[HttpGet]
        //public ActionResult Eliminar(string id)
        //{
        //    empleados.DeleteOneDocument(id);
        //    return RedirectToAction("Index");
        //}

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
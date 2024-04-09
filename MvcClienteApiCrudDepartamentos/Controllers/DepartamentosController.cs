using Microsoft.AspNetCore.Mvc;
using MvcClienteApiCrudDepartamentos.Models;
using MvcClienteApiCrudDepartamentos.Services;

namespace MvcClienteApiCrudDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        private ServiceApiDepartamentos service;

        public DepartamentosController(ServiceApiDepartamentos service)
        {
            this.service = service;
        }

        public IActionResult Cliente()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.service.GetDepartamentosAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int idDepartamento)
        {
            Departamento departamento = await this.service.GetDepartamentoAsync(idDepartamento);
            return View(departamento);
        }

        public async Task<IActionResult> Delete(int idDepartamento)
        {
            await this.service.DeleteDepartamentoAsync(idDepartamento);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.service.InsertDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Departamento departamento = await this.service.GetDepartamentoAsync(id);
            return View(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento dept)
        {
            await this.service.UpdateDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
    }
}

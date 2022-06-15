using InstituicoesEnsino.Data;
using InstituicoesEnsino.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicoesEnsino.Controllers
{
    public class DepartamentosController : Controller
    {
        private Context dbContext;
        public DepartamentosController(Context _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            List<Departamento> lista = dbContext.Departamentos.ToList();
            return View(lista);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento)
        {
            dbContext.Departamentos.Add(departamento);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long id)
        {
            Departamento depto = dbContext.Departamentos.Where(i => i.DepartamentoID == id).First();
            return View(depto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento departamento)
        {
            dbContext.Departamentos.Update(departamento);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(long id)
        {
            Departamento depto = dbContext.Departamentos.Where(i => i.DepartamentoID == id).First();
            return View(depto);
        }
        public IActionResult Delete(long id)
        {
            Departamento depto = dbContext.Departamentos.Where(i => i.DepartamentoID == id).First();
            return View(depto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Departamento departamento)
        {
            dbContext.Departamentos.Remove(departamento);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

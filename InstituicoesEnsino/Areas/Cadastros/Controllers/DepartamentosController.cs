using InstituicoesEnsino.Data;
using Modelo.Cadastros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstituicoesEnsino.Data.DAL.Cadastros;
using Microsoft.AspNetCore.Authorization;

namespace InstituicoesEnsino.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    [Authorize]
    public class DepartamentosController : Controller
    {
        private DepartamentoDAL departamentoDal;
        private InstituicaoDAL instituicaoDAL;
        public DepartamentosController(Context _dbContext)
        {
            departamentoDal = new DepartamentoDAL(_dbContext);
            instituicaoDAL = new InstituicaoDAL(_dbContext);
        }
        private async Task<IActionResult> ConsultarDepartamentoPorID(long? id)
        {
            if (id == null)
                return NotFound();
            var depto = await departamentoDal.ObterDepartamentoPorID((long)id);
            return View(depto);

        }
        public IActionResult Index()
        {
            return View(departamentoDal.ObterDepartamentoPorNome());
        }
        public IActionResult Create()
        {
            var Instituicoes = instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList();
            Instituicoes.Insert(0, new Instituicao() { Nome = "Selecione a Instituicao" });
            ViewBag.Instituicoes = Instituicoes;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,InstituicaoID")] Departamento departamento)
        {
            await departamentoDal.GravarDepartamento(departamento);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(long id)
        {
            Departamento depto = await departamentoDal.ObterDepartamentoPorID(id);
            List<Instituicao> lista = instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList();
            ViewBag.Instituicoes = lista;
            return View(depto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Departamento departamento)
        {
            await departamentoDal.GravarDepartamento(departamento);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(long id)
        {
            return await ConsultarDepartamentoPorID(id);

        }
        public async Task<IActionResult> Delete(long id)
        {
            return await ConsultarDepartamentoPorID(id);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            Departamento depto = await departamentoDal.ExcluirDepartamento(id);
            TempData["Message"] = "Departamento " + depto.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}

using InstituicoesEnsino.Data;
using Modelo.Cadastros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using InstituicoesEnsino.Data.DAL.Cadastros;

namespace InstituicoesEnsino.Controllers
{
    public class InstituicoesController : Controller
    {
        private Context dbContext;
        private InstituicaoDAL dalInstituicao;
        public InstituicoesController(Context context)
        {
            dbContext = context;
            dalInstituicao = new InstituicaoDAL(context);
        }
        public IActionResult Index()
        {
            return View(dalInstituicao.ObterInstituicoesClassificadasPorNome().ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instituicao novaInstituicao)
        {
            dbContext.Instituicoes.Add(novaInstituicao);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long id)
        {
            Instituicao instituicao = dbContext.Instituicoes.Where(i => i.InstituicaoID == id).First();
            return View(instituicao);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Instituicao instituicao)
        {
            dbContext.Instituicoes.Update(instituicao);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(long id)
        {
            Instituicao instituicao = dbContext.Instituicoes.Where(i => i.InstituicaoID == id).First();
            return View(instituicao);
        }
        [HttpPost]
        public IActionResult Delete(Instituicao instituicao)
        {
            dbContext.Instituicoes.Remove(instituicao);
            dbContext.SaveChanges();
            TempData["Message"] = "Instituição " + instituicao.Nome.ToUpper() + " foi removida";
            return RedirectToAction("Index");
        }
        public IActionResult Details(long id)
        {
            Instituicao inst = dbContext.Instituicoes.Include(d=>d.Departamentos).SingleOrDefault(i => i.InstituicaoID == id);
            return View(inst);
        }
    }
}

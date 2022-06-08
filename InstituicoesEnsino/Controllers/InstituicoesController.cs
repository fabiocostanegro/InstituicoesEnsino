using InstituicoesEnsino.Data;
using InstituicoesEnsino.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InstituicoesEnsino.Controllers
{
    public class InstituicoesController : Controller
    {
        private Context dbContext;
        public InstituicoesController(Context context)
        {
            dbContext = context;    
        }
        public IActionResult Index()
        {
            List<Instituicao> instituicao = dbContext.Instituicoes.ToList();
            return View(instituicao);
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
            return RedirectToAction("Index");
        }
    }
}

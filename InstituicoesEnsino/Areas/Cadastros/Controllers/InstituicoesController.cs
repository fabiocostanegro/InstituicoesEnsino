using InstituicoesEnsino.Data;
using Modelo.Cadastros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using InstituicoesEnsino.Data.DAL.Cadastros;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    [Authorize]
    public class InstituicoesController : Controller
    {
        private Context dbContext;
        private InstituicaoDAL dalInstituicao;
        public InstituicoesController(Context context)
        {
            dbContext = context;
            dalInstituicao = new InstituicaoDAL(context);
        }
        private async Task<ActionResult> ObterInstituicaoPorId(long? id)
        {
            if (id == null)
                return NotFound();
            
            var instituicao = await dalInstituicao.ObterInstituicaoPorId((long)id);
            if (instituicao == null)
                return NotFound();
            
            return View(instituicao);

            
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
        public async Task<IActionResult> Create(Instituicao novaInstituicao)
        {
            await dalInstituicao.GravarInstituicao(novaInstituicao);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(long? id)
        {
            return await ObterInstituicaoPorId(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Instituicao instituicao)
        {
            await dalInstituicao.GravarInstituicao(instituicao);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterInstituicaoPorId(id);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Instituicao instituicao)
        {
            await dalInstituicao.EliminarInstituicaoPorId((long)instituicao.InstituicaoID);
            TempData["Message"] = "Instituição " + instituicao.Nome.ToUpper() + " foi removida";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterInstituicaoPorId(id);
        }
    }
}

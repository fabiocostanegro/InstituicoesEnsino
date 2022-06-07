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
    }
}

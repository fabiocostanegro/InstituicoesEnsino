using InstituicoesEnsino.Data;
using InstituicoesEnsino.Data.DAL.Cadastros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicoesEnsino.Controllers
{
    public class CursosController : Controller
    {
        private CursoDAL cursoDAL;
        private DepartamentoDAL departamentoDAL;
        private InstituicaoDAL instituicaoDAL;
        public CursosController(Context dbContext)
        {
            cursoDAL = new CursoDAL(dbContext);
            departamentoDAL = new DepartamentoDAL(dbContext);
            instituicaoDAL = new InstituicaoDAL(dbContext);
        }
        public async Task<IActionResult> Index(long id, string nome)
        {
            List<Curso> listaCursos = await cursoDAL.ConsultarCursosPorDepartamento(id).ToListAsync();
            ViewBag.NomeDepartamento = nome;
            ViewBag.Id = id;
            return View(listaCursos);
        }
        public async Task<IActionResult> Create(long idDepto)
        {
            Departamento depto = await departamentoDAL.ObterDepartamentoPorID(idDepto);
            ViewBag.Departamento = depto;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Curso curso)
        {
            curso.DepartamentoID = Convert.ToInt64(HttpContext.Request.Form["DepartamentoID"]);
            await cursoDAL.GravarCurso(curso);
            return RedirectToAction("Index",new RouteValueDictionary(new { id=curso.DepartamentoID, nome=HttpContext.Request.Form["DepartamentoNome"] }));
        }
    }
}

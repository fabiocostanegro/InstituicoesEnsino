using InstituicoesEnsino.Data;
using InstituicoesEnsino.Data.DAL.Cadastros;
using Microsoft.AspNetCore.Mvc;
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
        public CursosController(Context dbContext)
        {
            cursoDAL = new CursoDAL(dbContext);
            departamentoDAL = new DepartamentoDAL(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            List<Curso> listaCursos = await cursoDAL.ConsultarCursos().ToListAsync();
            return View(listaCursos);
        }
        public async Task<IActionResult> Create()
        {
            List<Departamento> listaDepto = departamentoDAL.ObterDepartamentoPorNome().ToList();
            ViewBag.Departamentos = listaDepto;
            return View();
        }
    }
}

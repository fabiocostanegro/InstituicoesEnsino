﻿using InstituicoesEnsino.Data;
using InstituicoesEnsino.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<Departamento> lista = dbContext.Departamentos.Include(i => i.Instituicao).OrderBy(c => c.Nome).ToList();
            return View(lista);
        }
        public IActionResult Create()
        {
            var Instituicoes = dbContext.Instituicoes.OrderBy(c => c.Nome).ToList();
            Instituicoes.Insert(0, new Instituicao() { Nome = "Selecione a Instituicao" });
            ViewBag.Instituicoes = Instituicoes;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,InstituicaoID")] Departamento departamento)
        {
            dbContext.Departamentos.Add(departamento);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long id)
        {
            Departamento depto = dbContext.Departamentos.Where(i => i.DepartamentoID == id).First();
            List<Instituicao> lista = dbContext.Instituicoes.OrderBy(i => i.Nome).ToList();
            ViewBag.Instituicoes = lista;
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
            dbContext.Instituicoes.Where(i => i.InstituicaoID == depto.InstituicaoID).Load();
            return View(depto);
        }
        public IActionResult Delete(long id)
        {
            Departamento depto = dbContext.Departamentos.Where(i => i.DepartamentoID == id).First();
            dbContext.Instituicoes.Where(i => i.InstituicaoID == depto.InstituicaoID).Load();
            return View(depto);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            Departamento depto = dbContext.Departamentos.Where(i => i.DepartamentoID == id).FirstOrDefault();
            dbContext.Departamentos.Remove(depto);
            dbContext.SaveChanges();
            TempData["Message"] = "Departamento " + depto.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}

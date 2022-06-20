﻿using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;

namespace InstituicoesEnsino.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) :base(options)
        {
                
        }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}

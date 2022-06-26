using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;
using Modelo.Discente;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using InstituicoesEnsino.Models.Infra;

namespace InstituicoesEnsino.Data
{
    public class Context: IdentityDbContext<UsuarioDaAplicacao>
    {
        public Context(DbContextOptions<Context> options) :base(options)
        {
                
        }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Academico> Academicos { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Define a chave primaria
            modelBuilder.Entity<CursoDisciplina>()
                .HasKey(cd => new { cd.CursoID, cd.DisciplinaID });

            //Define relacionamento de Curso Disciplina com curso
            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(c => c.Curso)
                .WithMany(d => d.CursoDisciplinas)
                .HasForeignKey(c => c.CursoID);

            //Define relacionamento de Curso Disciplina com disciplina
            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(d => d.Disciplina)
                .WithMany(cd => cd.CursosDisciplinas)
                .HasForeignKey(d => d.DisciplinaID);


        }
    }
}

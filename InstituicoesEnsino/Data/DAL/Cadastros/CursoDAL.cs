using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Modelo.Docente;

namespace InstituicoesEnsino.Data.DAL.Cadastros
{
    public class CursoDAL
    {
        private Context _context;
        public CursoDAL(Context dbContext)
        {
            _context = dbContext;
        }
        public IQueryable<Curso> ConsultarCursosPorDepartamento(long idDepartamento)
        {
            IQueryable<Curso> cursos = _context.Cursos.Where(i => i.DepartamentoID == idDepartamento).Include(d => d.Departamento);
            return cursos;
        }
        public async Task<Curso> GravarCurso(Curso curso)
        {
            if (curso.CursoID == null)
                _context.Cursos.Add(curso);
            else
                _context.Cursos.Update(curso);
            
            await _context.SaveChangesAsync();
            
            return curso;

        }
        public void RegistrarProfessor(long cursoID, long professorID)
        {
            var curso = _context.Cursos.Where(c => c.CursoID == cursoID).Include(cp => cp.CursoProfessores).First();
            var professor = _context.Professores.Find(professorID);
            curso.CursoProfessores.Add(new CursoProfessor() { Curso = curso, Professor = professor });
            _context.SaveChanges();
        }

        public IQueryable<Curso> ObterCursosPorDepartamento(long departamentoID)
        {
            var cursos = _context.Cursos.Where(c => c.DepartamentoID == departamentoID).OrderBy(d => d.Nome);
            return cursos;
        }

        public IQueryable<Professor> ObterProfessoresForaDoCurso(long cursoID)
        {
            var curso = _context.Cursos.Where(c => c.CursoID == cursoID).Include(cp => cp.CursoProfessores).First();
            var professoresDoCurso = curso.CursoProfessores.Select(cp => cp.ProfessorID).ToArray();
            var professoresForaDoCurso = _context.Professores.Where(p => !professoresDoCurso.Contains(p.ProfessorID));
            return professoresForaDoCurso;
        }
    }
}

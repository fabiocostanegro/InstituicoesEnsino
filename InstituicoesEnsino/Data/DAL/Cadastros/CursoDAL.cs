using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace InstituicoesEnsino.Data.DAL.Cadastros
{
    public class CursoDAL
    {
        private Context contexto;
        public CursoDAL(Context dbContext)
        {
            contexto = dbContext;
        }
        public IQueryable<Curso> ConsultarCursosPorDepartamento(long idDepartamento)
        {
            IQueryable<Curso> cursos = contexto.Cursos.Where(i => i.DepartamentoID == idDepartamento).Include(d => d.Departamento);
            return cursos;
        }
        public async Task<Curso> GravarCurso(Curso curso)
        {
            if (curso.CursoID == null)
                contexto.Cursos.Add(curso);
            else
                contexto.Cursos.Update(curso);
            
            await contexto.SaveChangesAsync();
            
            return curso;

        }
    }
}

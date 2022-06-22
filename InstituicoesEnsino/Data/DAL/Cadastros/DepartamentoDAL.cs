using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicoesEnsino.Data.DAL.Cadastros
{
    public class DepartamentoDAL
    {
        private Context dbContext;
        public DepartamentoDAL(Context contexto)
        {
            dbContext = contexto;
        }
        public IQueryable<Departamento> ObterDepartamentoPorNome()
        {
            return dbContext.Departamentos.Include(d=>d.Instituicao).OrderBy(i => i.Nome);
        }
        public async Task<Departamento> ObterDepartamentoPorID(long id)
        {
            Departamento dept = await dbContext.Departamentos.Where(i => i.DepartamentoID == id).FirstOrDefaultAsync();
            dbContext.Instituicoes.Where(i => i.InstituicaoID == dept.InstituicaoID).Load();
            return dept;
        }
        public async Task<Departamento> GravarDepartamento(Departamento depto)
        {
            if (depto.DepartamentoID != null)
                dbContext.Departamentos.Update(depto);
            else
                dbContext.Departamentos.Add(depto);
            await dbContext.SaveChangesAsync();
            return depto;
        }
        public async Task<Departamento> ExcluirDepartamento(long id)
        {
            Departamento depto = await this.ObterDepartamentoPorID(id);
            dbContext.Departamentos.Remove(depto);
            await dbContext.SaveChangesAsync();
            return depto;

        }
    }
}

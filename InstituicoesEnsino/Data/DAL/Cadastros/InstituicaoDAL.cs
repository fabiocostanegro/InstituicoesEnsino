using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstituicoesEnsino.Data.DAL.Cadastros
{
    public class InstituicaoDAL
    {
        private Context dbContext;
        public InstituicaoDAL(Context context)
        {
            dbContext = context;
        }
        public IQueryable<Instituicao> ObterInstituicoesClassificadasPorNome()
        {
            return dbContext.Instituicoes.OrderBy(i => i.Nome);
        }
        public async Task<Instituicao> ObterInstituicaoPorId(long id)
        {
            return await dbContext.Instituicoes.Include(d => d.Departamentos).Where(i => i.InstituicaoID == id).FirstOrDefaultAsync();
        }
        public async Task<Instituicao> GravarInstituicao(Instituicao instituicao)
        {
            if (instituicao.InstituicaoID == null)
                dbContext.Instituicoes.Add(instituicao);
            else
                dbContext.Instituicoes.Update(instituicao);
            
            await dbContext.SaveChangesAsync();
            
            return instituicao;
        }
        public async Task<Instituicao> EliminarInstituicaoPorId(long id)
        {
            Instituicao inst = await ObterInstituicaoPorId(id);
            dbContext.Instituicoes.Remove(inst);
            await dbContext.SaveChangesAsync();
            return inst;

        }
        public async Task<bool> InstituicaoExists(long? id)
        {
            return await ObterInstituicaoPorId((long)id) != null;
            
        }

    }
}

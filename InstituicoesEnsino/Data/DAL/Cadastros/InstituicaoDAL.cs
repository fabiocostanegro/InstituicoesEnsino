using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    }
}

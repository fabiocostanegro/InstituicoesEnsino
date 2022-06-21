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
            return dbContext.Departamentos.OrderBy(i => i.Nome);
        }
    }
}

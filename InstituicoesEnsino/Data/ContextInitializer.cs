using Modelo.Cadastros;
using System.Linq;

namespace InstituicoesEnsino.Data
{
    public static class ContextInitializer
    {
        public static void InicializarBancodeDados(Context dbContext)
        {
            dbContext.Database.EnsureDeleted(); 
            dbContext.Database.EnsureCreated();
            InicializaInstituicoes(dbContext);
            InicializaDepartamentos(dbContext);


        }
        private static void InicializaInstituicoes(Context dbContext)
        {
            if (dbContext.Instituicoes.Any())
                return;
            else
            {
                var instituicoes = new Instituicao[]
                {
                    new Instituicao { Nome="UniParaná", Endereco="Paraná"},
                    new Instituicao { Nome="UniAcre", Endereco="Acre"}
                };
                foreach (Instituicao i in instituicoes)
                {
                    dbContext.Instituicoes.Add(i);
                }
                dbContext.SaveChanges();
            }
        }
        private static void InicializaDepartamentos(Context dbContext)
        {
            if (dbContext.Departamentos.Any())
                return;
            else
            {
                var departamentos = new Departamento[]
                {
                    new Departamento { Nome="Ciência da Computação", InstituicaoID=1 },
                    new Departamento { Nome="Ciência de Alimentos", InstituicaoID=2}
                };
                foreach (Departamento d in departamentos)
                {
                    dbContext.Departamentos.Add(d);
                }
                dbContext.SaveChanges();
            }
        }
    }
}

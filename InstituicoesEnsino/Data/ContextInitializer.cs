using System.Linq;

namespace InstituicoesEnsino.Data
{
    public static class ContextInitializer
    {
        public static void InicializarBancodeDados(Context dbContext)
        {
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
                dbContext.Instituicoes.Add(new Models.Instituicao() { Nome = "Instituição teste", Endereco = "Rua das instituiçoes" });
                dbContext.SaveChanges();
            }
        }
        private static void InicializaDepartamentos(Context dbContext)
        {
            if (dbContext.Departamentos.Any())
                return;
            else
            {
                dbContext.Departamentos.Add(new Models.Departamento() { Nome = "Departamento Teste" });
                dbContext.SaveChanges();
            }
        }
    }
}

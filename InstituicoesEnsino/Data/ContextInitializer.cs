using System.Linq;

namespace InstituicoesEnsino.Data
{
    public static class ContextInitializer
    {
        public static void InicializarBancodeDados(Context dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (dbContext.Instituicoes.Any())
                return;
            
            dbContext.Instituicoes.Add(new Models.Instituicao() { Nome = "Instituição teste", Endereco = "Rua das instituiçoes" });
            dbContext.SaveChanges();
            
        }
    }
}

﻿namespace InstituicoesEnsino.Models
{
    public class Departamento
    {
        public string Nome { get; set; }
        public long? DepartamentoID { get; set; }
        public long InstituicaoID { get; set; }
        public Instituicao Instituicao { get; set; }

    }
}

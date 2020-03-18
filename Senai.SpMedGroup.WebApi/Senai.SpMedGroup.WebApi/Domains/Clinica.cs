using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medico = new HashSet<Medico>();
        }

        public int Idclinica { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string HorarioFuncionamento { get; set; }

        public ICollection<Medico> Medico { get; set; }
    }
}

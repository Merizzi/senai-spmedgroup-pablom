using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medico = new HashSet<Medico>();
        }

        public int Idespecialidade { get; set; }
        public string Especialidade1 { get; set; }

        public ICollection<Medico> Medico { get; set; }
    }
}

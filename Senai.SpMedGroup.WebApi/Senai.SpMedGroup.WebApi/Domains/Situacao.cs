using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Idsituacao { get; set; }
        public string Titulo { get; set; }

        public ICollection<Consulta> Consulta { get; set; }
    }
}

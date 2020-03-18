using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Domains
{
    public partial class Consulta
    {
        public int Idconsulta { get; set; }
        public DateTime? DataConsulta { get; set; }
        public string Descricao { get; set; }
        public int? IdMedico { get; set; }
        public int? IdSituacao { get; set; }
        public int? IdProntuario { get; set; }

        public Medico IdMedicoNavigation { get; set; }
        public Prontuario IdProntuarioNavigation { get; set; }
        public Situacao IdSituacaoNavigation { get; set; }
    }
}

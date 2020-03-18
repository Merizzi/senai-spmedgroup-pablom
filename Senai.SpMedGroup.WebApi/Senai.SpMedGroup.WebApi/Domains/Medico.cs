﻿using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Idmedico { get; set; }
        public string Crm { get; set; }
        public string Nome { get; set; }
        public int? IdClinica { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEspecialidade { get; set; }

        public Clinica IdClinicaNavigation { get; set; }
        public Especialidade IdEspecialidadeNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}

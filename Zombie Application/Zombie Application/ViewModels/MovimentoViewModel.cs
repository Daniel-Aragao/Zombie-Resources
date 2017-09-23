using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zombie_Application.ViewModels
{
    public class MovimentoViewModel
    {
        public int Id { get; set; }
        public int Antes { get; set; }
        public int Depois { get; set; }
        public string Descricao { get; set; }
        public ETipoMovimento TipoMovimento { get; set; }
        public DateTime Data { get; set; }

        public int RecursoId { get; set; }
        public Recurso Recurso { get; set; }

        public int ResponsavelId { get; set; }
        public String Responsavel { get; set; }
    }
}
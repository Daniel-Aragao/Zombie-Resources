using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zombie_Application.ViewModels
{
    public class MovimentarViewModel
    {
        public int RecursoId { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Movimento : IValidation
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
        public Usuario Responsavel { get; set; }

        public Movimento()
        {

        }

        public IEnumerable<KeyValuePair<string, string>> Validar()
        {
            var errors = new List<KeyValuePair<string, string>>();

            if(Recurso == null)
            {
                errors.Add(new KeyValuePair<string, string>("Recurso", "Escolha o Recurso"));
            }

            if (Responsavel == null)
            {
                errors.Add(new KeyValuePair<string, string>("Responsavel", "Escolha o Responsável"));
            }

            if (Antes > Depois && TipoMovimento != ETipoMovimento.Saída)
            {
                errors.Add(new KeyValuePair<string, string>("TipoMovimento", "Tipo de movimento deveria ser de saída"));

            }else if (Antes < Depois && TipoMovimento != ETipoMovimento.Entrada)
            {
                errors.Add(new KeyValuePair<string, string>("TipoMovimento", "Tipo de movimento deveria ser de entrada"));
            }else if(Antes == Depois)
            {
                errors.Add(new KeyValuePair<string, string>("TipoMovimento", "Não houve movimentação"));
            }

            if (String.IsNullOrWhiteSpace(Descricao))
            {
                errors.Add(new KeyValuePair<string, string>("Descricao", "Descreva a movimentação"));
            }

            return errors;
        }
    }
}

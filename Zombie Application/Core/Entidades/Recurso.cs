using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Recurso : IValidation
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
        public bool isActive { get; set; }

        public bool IsDisponivel {
            get
            {
                return Quantidade > 0;
            }
        }

        public Recurso()
        {
            isActive = true;
        }

        public Movimento CriarMovimento(Usuario user, string descricao, int quantidade)
        {
            var mov = new Movimento()
            {
                Responsavel = user,
                Antes = Quantidade,
                Depois = Quantidade + quantidade,
                Descricao = descricao,
                Recurso = this,
                TipoMovimento = (quantidade > 0 ? ETipoMovimento.Entrada : ETipoMovimento.Saída),
                Data = DateTime.Now
            };

            Quantidade += quantidade;

            return mov;
        }

        public IEnumerable<KeyValuePair<string, string>> Validar()
        {
            var errors = new List<KeyValuePair<string, string>>();

            if (String.IsNullOrWhiteSpace(Descricao))
            {
                errors.Add(new KeyValuePair<string, string>("Descricao", "Preencha a Descrição"));
            }

            if (Quantidade < 0)
            {
                errors.Add(new KeyValuePair<string, string>("Quantidade", "Insira recursos antes de tentar remove-los"));
            }

            return errors;
        }
    }
}

using Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Usuario :IValidation 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {

        }

        public bool Autenticar(string senha)
        {
            return (new Senha(senha)).Validar(Senha);
        }

        public IEnumerable<KeyValuePair<string, string>> Validar()
        {
            var errors = new List<KeyValuePair<string, string>>();

            if (String.IsNullOrWhiteSpace(Nome))
            {
                errors.Add(new KeyValuePair<string, string>("Nome", "Preencha o nome"));
            }

            if (String.IsNullOrWhiteSpace(Senha))
            {
                errors.Add(new KeyValuePair<string, string>("Senha", "Preencha a Senha"));
            }

            if (String.IsNullOrWhiteSpace(Login))
            {
                errors.Add(new KeyValuePair<string, string>("Login", "Preencha o Login"));
            }

            return errors;
        }
    }
}

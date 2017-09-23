using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.ValueObjects
{
    public class Senha
    {
        public string crypt { get; private set; }

        public Senha(string senha)
        {
            crypt = Criptografar(senha);
        }

        private string Criptografar(string senha)
        {
            if (String.IsNullOrWhiteSpace(senha)) return null;

            Byte[] tmphash;  
            Byte[] tmpsource;

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            tmpsource = System.Text.ASCIIEncoding.ASCII.GetBytes(senha);
            tmphash = md5.ComputeHash(tmpsource);

            System.Text.StringBuilder sb = new System.Text.StringBuilder(tmphash.Length);

            for (int i = 0; i <= tmphash.Length - 1; i++)
            {
                sb.Append(tmphash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public bool Validar(string senhaCrypt)
        {
            return senhaCrypt.ToUpper() == crypt.ToUpper();
        }
    }
}

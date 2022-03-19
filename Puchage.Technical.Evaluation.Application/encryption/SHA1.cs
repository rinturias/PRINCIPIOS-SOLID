using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Usuarios.Technical.Evaluation.Application.encryption
{
   public class SHA1: IEncryption, IDecrypt
    {


        public SHA1()
        {

        }
        public  string encryption(string str)
        {
            System.Security.Cryptography.SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public string decrypt(string str)
        {
            System.Security.Cryptography.SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] combined = encoder.GetBytes(str);
            string hash = BitConverter.ToString(sha1.ComputeHash(combined)).Replace("-", "");

            return hash;
        }

       
    }
}

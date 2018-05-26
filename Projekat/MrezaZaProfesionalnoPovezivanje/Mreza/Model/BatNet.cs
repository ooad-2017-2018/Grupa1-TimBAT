using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mreza.Model
{
    public static class BatNet
    {
        private static List<Korisnik> korisnici = new List<Korisnik>();
        private static List<Projekat> projekti = new List<Projekat>();
        private static List<Tehnologija> tehnologije = new List<Tehnologija>();

        public static List<Korisnik> Korisnici { get => korisnici; set => korisnici = value; }
        public static List<Projekat> Projekti { get => projekti; set => projekti = value; }
        public static List<Tehnologija> Tehnologije { get => tehnologije; set => tehnologije = value; }

        public static Korisnik NadjiKorisnika(String user, String pass)
        {
            foreach(Korisnik kor in Korisnici) {
                if(kor.KorisnickoIme.Equals(user)) System.Diagnostics.Debug.Write("Nadje username");
                if (kor.KorisnickoIme.Equals(user) && kor.Password.Equals(pass))
                {
                    System.Diagnostics.Debug.Write("Nadje sve lel");
                    return kor;
                }
            }
            return null;
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}

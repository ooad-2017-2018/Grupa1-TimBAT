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
    }
}

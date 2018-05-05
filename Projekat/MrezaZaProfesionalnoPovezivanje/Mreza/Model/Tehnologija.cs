using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mreza.Model
{

    public enum TipTehnologije{ProgramskiJezik, Framework, BazaPodataka, IDE, TypeSetting, OperativniSisem, MobilnoProgramiranje};

    public class Tehnologija
    {
        private String naziv;
        private TipTehnologije tipTehnologije;

        public Tehnologija(string naziv, TipTehnologije tipTehnologije)
        {
            Naziv = naziv;
            TipTehnologije = tipTehnologije;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public TipTehnologije TipTehnologije { get => tipTehnologije; set => tipTehnologije = value; }
    }
}

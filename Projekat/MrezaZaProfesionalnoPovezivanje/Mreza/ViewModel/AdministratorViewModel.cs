using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mreza.Model;

namespace Mreza.ViewModel
{
    class AdministratorViewModel
    {
        public ICommand ObrisiKorisnika, ObrisiProjekat, Poruke;

        public AdministratorViewModel()
        {
            //ObrisiKorisnika = new RelayCommand<object>(obrisi, mozeLiSeObrisati);
        }
    }
}

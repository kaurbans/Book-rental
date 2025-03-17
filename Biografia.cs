using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Biografia : Ksiazka
    {
        static decimal dodatkowaOplataZaZgubienie;
        static Biografia()
        {
            dodatkowaOplataZaZgubienie = 1;
        }
        string osobaBiografia;
        public string OsobaBiografia { get => osobaBiografia; set => osobaBiografia = value; }
        public Biografia() :base() { }
        public Biografia(string tytul, string autor, int rokWydania, string osobaBiografia)
            : base(tytul, autor, rokWydania)
        {
            OsobaBiografia = osobaBiografia;
        }

        public override decimal ObliczCene()
        {
            return base.ObliczCene() + dodatkowaOplataZaZgubienie;
        }

        public override string ToString()
        {
            return $"BIOGRAFIA \nBiografia Osoby : {OsobaBiografia} \n{base.ToString()} (w tym oplata dodatkowa {dodatkowaOplataZaZgubienie:c}) ";
        }
    }
}

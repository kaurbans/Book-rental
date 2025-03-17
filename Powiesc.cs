using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public enum EnumRodzajPowiesci
    {
        Obyczajowa,
        Psychologiczna,
        Historyczna,
        Sensacyjna,
        Kryminalna,
        Fantastyczna,
        Przygodowa,
        ScienceFiction,
        Dystopijna,
        Romantyczna,
        Satyryczna,
        Filozoficzna,
        Epistolarna,
        Gotycka,
        Autobiograficzna,
        Edukacyjna
    }

    public class Powiesc : Ksiazka
    {
        EnumRodzajPowiesci rodzajLiteratury;
        public EnumRodzajPowiesci RodzajLiteratury { get => rodzajLiteratury; set => rodzajLiteratury = value; }
        static decimal dodatkowaOplataZaZgubienie;
        static Powiesc()
        {
            dodatkowaOplataZaZgubienie = 10;
        }
        public Powiesc() :base() { } 
        public Powiesc(string tytul, string autor, int rokWydania, EnumRodzajPowiesci rodzajLiteratury)
            : base(tytul, autor, rokWydania)
        {
            RodzajLiteratury = rodzajLiteratury;
        }


        public override decimal ObliczCene()
        {
            return base.ObliczCene() + dodatkowaOplataZaZgubienie;
        }

        public override string ToString()
        {
            return $"POWIEŚĆ \n{base.ToString()}(w tym oplata dodatkowa {dodatkowaOplataZaZgubienie:c}) \nRodzaj literatury: {RodzajLiteratury}";
        }
    }
}

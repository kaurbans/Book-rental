using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public enum EnumRodzajPoradnika
    {
        Samopomocowy,
        RozwojuOsobistego,
        Zdrowotny,
        Podróżniczy,
        Kucharski,
        Finansowy,
        Biznesowy,
        Technologiczny,
        Ogrodniczy,
        Fitness,
        Psychologiczny,
        ZrównoważonegoRozwoju,
        Edukacyjny,
        StyluŻycia,
        Kreatywny,
        Rodzinny,
        Budowlany,
        Fotograficzny
    }

    public class Poradnik : Ksiazka
    {
        EnumRodzajPoradnika tematyka;
        static decimal dodatkowaOplataZaZgubienie;
        static Poradnik()
        {
            dodatkowaOplataZaZgubienie = 1;
        }
        public EnumRodzajPoradnika Tematyka { get => tematyka; set => tematyka = value; }
       
        public Poradnik(): base() { }
       

        public Poradnik(string tytul, string autor, int rokWydania, EnumRodzajPoradnika tematyka)
            : base(tytul, autor, rokWydania)
        {
            Tematyka = tematyka;
        }


        public override decimal ObliczCene()
        {
            return base.ObliczCene() + dodatkowaOplataZaZgubienie;   
        }
        public override string ToString()
        {
            return $"PORADNIK  \n{base.ToString()} (w tym oplata dodatkowa {dodatkowaOplataZaZgubienie:c} )" + $"\nTematyka : {Tematyka}";
        }

    }
}
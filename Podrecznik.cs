using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public enum EnumPoziomEdukacji
    {
        Przedszkole,
        Podstawowka,
        Gimnazjum,
        Liceum,
        Technikum,
        Zawodowka,
        Licencjat,
        Magister,
        Doktorat,
        Podyplomowe,
        Kursy,
        Szkolenia
    }

    public class Podrecznik : Ksiazka
    {
        string przedmiot;
        EnumPoziomEdukacji poziomEdukacji;
        static decimal dodatkowaOplataZaZgubienie;
        static Podrecznik()
        {
            dodatkowaOplataZaZgubienie = 10;
        }
        public string Przedmiot { get => przedmiot; set => przedmiot = value; }
        public EnumPoziomEdukacji PoziomEdukacji { get => poziomEdukacji; set => poziomEdukacji = value; }
        public Podrecznik() :base() { }
        public Podrecznik(string tytul, string autor, int rokWydania, string przedmiot, EnumPoziomEdukacji poziomEdukacji)
            : base(tytul, autor, rokWydania)
        {
            Przedmiot = przedmiot;
            PoziomEdukacji = poziomEdukacji;
        }
        public override decimal ObliczCene()
        {
            return base.ObliczCene() + dodatkowaOplataZaZgubienie;
        }

        public override string ToString()
        {
            return $"PODRĘCZNIK (poziom - {PoziomEdukacji}) \nPrzedmiot : - {Przedmiot} \n{base.ToString()} (w tym oplata dodatkowa {dodatkowaOplataZaZgubienie:c})";
        }
    }
}

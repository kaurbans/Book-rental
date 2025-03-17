using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Encyklopedia : Ksiazka
    {
        string zakresTematyczny;
        int numerTomu;
        decimal dodatkowaOplataZaZgubienie;
        public string ZakresTematyczny { get => zakresTematyczny; set => zakresTematyczny = value; }
        public int NumerTomu { get => numerTomu; set => numerTomu = value; }
        public decimal DodatkowaOplataZaZgubienie { get => dodatkowaOplataZaZgubienie; set => dodatkowaOplataZaZgubienie = value; }

        public Encyklopedia():base() { }
        public Encyklopedia(string tytul, string autor, int rokWydania, string zakresTematyczny, int numerTomu)
            : base(tytul, autor, rokWydania)
        {
            Random r = new();
            ZakresTematyczny = zakresTematyczny;
            NumerTomu = numerTomu;
            DodatkowaOplataZaZgubienie = r.Next(1, 20);
        }
        
        
        public override decimal ObliczCene()
        {
            return base.ObliczCene() + DodatkowaOplataZaZgubienie;
        }
        public override string ToString()
        {
            return $"ENCYKLOPEDIA\n{base.ToString()} (w tym oplata dodatkowa {DodatkowaOplataZaZgubienie:c}) \nTematyka: {ZakresTematyczny} \nNumer tomu: {NumerTomu}";
        }
    }
}

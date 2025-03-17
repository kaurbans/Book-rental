using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Projekt
{

    [XmlInclude(typeof(Poradnik))]
    [XmlInclude(typeof(Powiesc))]
    [XmlInclude(typeof(Biografia))]
    [XmlInclude(typeof(Podrecznik))]
    [XmlInclude(typeof(Encyklopedia))]
    public class Biblioteka
    {

        string nazwaBiblioteki;
        List<Ksiazka> wszystkieKsiazki;
        List<Ksiazka> dostepneKsiazki;
        List<Ksiazka> wypozyczoneKsiazki;
        List<Ksiazka> zgubioneKsiazki;

        public string NazwaBiblioteki { get => nazwaBiblioteki; set => nazwaBiblioteki = value; }
        public List<Ksiazka> WszystkieKsiazki { get => wszystkieKsiazki; }
        public List<Ksiazka> DostepneKsiazki { get => dostepneKsiazki; }
        public List<Ksiazka> WypozyczoneKsiazki { get => wypozyczoneKsiazki; }
        public List<Ksiazka> ZgubioneKsiazki { get => zgubioneKsiazki; set => zgubioneKsiazki = value; }

        public Biblioteka()
        {
            NazwaBiblioteki = string.Empty;
            wszystkieKsiazki = new List<Ksiazka>();
            dostepneKsiazki = new List<Ksiazka>();
            wypozyczoneKsiazki = new List<Ksiazka>();
            zgubioneKsiazki = new List<Ksiazka>();
        }


        public Biblioteka(string nazwaBiblioteki) : this()
        {
            NazwaBiblioteki = nazwaBiblioteki;
        }


        public void DodajKsiazke(Ksiazka ksiazka)
        {
            wszystkieKsiazki.Add(ksiazka);
            dostepneKsiazki.Add(ksiazka);
        }


        public void WypozyczKsiazke(Ksiazka ksiazka)
        {
            if (dostepneKsiazki.Contains(ksiazka))
            {
                dostepneKsiazki.Remove(ksiazka);
                wypozyczoneKsiazki.Add(ksiazka);
                Console.WriteLine($"Ksiazka {ksiazka.Tytul} została wypożyczona ");
            }
            else
            {
                Console.WriteLine("Książka jest już wypożyczona lub nie istnieje w bibliotece.");
            }
        }


        public void ZwrocKsiazke(string isbn, bool czyZgubiona)
        {
            Ksiazka ksiazka = wszystkieKsiazki.FirstOrDefault(k => k.ISBN == isbn);

            if (ksiazka != null)
            {
                if (wypozyczoneKsiazki.Contains(ksiazka))
                {
                    if (czyZgubiona)
                    {
                        wypozyczoneKsiazki.Remove(ksiazka);
                        zgubioneKsiazki.Add(ksiazka);
                        Console.WriteLine($"Książka o ISBN {isbn} została zgubiona i dodana do zgubionych.");
                    }
                    else
                    {
                        wypozyczoneKsiazki.Remove(ksiazka);
                        dostepneKsiazki.Add(ksiazka);
                        Console.WriteLine($"Książka o ISBN {isbn} została zwrócona.");
                    }
                }
                else
                {
                    Console.WriteLine($"Książka o ISBN {isbn} nie jest aktualnie wypożyczona.");
                }
            }
            else
            {
                Console.WriteLine($"Książka o ISBN {isbn} nie istnieje w systemie.");
            }
        }

        public decimal SumaCen()
        {
            decimal suma = 0;
            foreach (Ksiazka ksiazka in zgubioneKsiazki)
            {
                suma += ksiazka.ObliczCene();
            }
            return suma;
        }

        public int LiczbaKsiazek()
        {
            return dostepneKsiazki.Count;
        }

        public void WyswietlWypozyczoneKsiazki()
        {
            if (wypozyczoneKsiazki.Count == 0)
            {
                Console.WriteLine("Brak wypożyczonych książek.");
            }
            else
            {
                Console.WriteLine("Wypożyczone książki:");
                foreach (Ksiazka ksiazka in wypozyczoneKsiazki)
                {
                    Console.WriteLine(ksiazka.ToString() + "\n");
                }
            }
        }

        public void WyswietlZgubioneKsiazki()
        {
            if (zgubioneKsiazki.Count == 0)
            {
                Console.WriteLine("Brak zgubionych książek.");
            }
            else
            {
                Console.WriteLine("Zgubione książki:");
                foreach (Ksiazka ksiazka in zgubioneKsiazki)
                {
                    Console.WriteLine(ksiazka.ToString() + "\n");
                }
            }
        }

        public List<Ksiazka> WyswietlKsiazkiWedlugKategorii(string kategoria)
        {
            List<Ksiazka> ksiazkiFiltr = new();

            foreach (Ksiazka ksiazka in dostepneKsiazki)
            {
                if (ksiazka.GetType().Name == kategoria || kategoria == "Wszystkie")
                {
                    ksiazkiFiltr.Add(ksiazka);
                }
            }

            return ksiazkiFiltr;
        }

        public void WyswietlKategorie()
        {

            List<string> kategorie = new();

            foreach (Ksiazka ksiazka in wszystkieKsiazki)
            {

                string kategoria = ksiazka.GetType().Name;

                if (!kategorie.Contains(kategoria))
                {
                    kategorie.Add(kategoria);
                }
            }


            if (!kategorie.Contains("Wszystkie"))
            {
                kategorie.Add("Wszystkie");
            }


            kategorie.Sort();


            if (kategorie.Count == 0)
            {
                Console.WriteLine("Brak dostępnych kategorii.");
                return;
            }


            Console.WriteLine("Kategorie książek:");
            foreach (string kategoria in kategorie)
            {
                Console.WriteLine(kategoria);
            }
        }



        public void SortujKsiazki()
        {
            wszystkieKsiazki.Sort();
            dostepneKsiazki.Sort();
            wypozyczoneKsiazki.Sort();
            zgubioneKsiazki.Sort();
            Console.WriteLine("Książki zostały posortowane alfabetycznie według tytułu.");
        }

        public Biblioteka KopiujBiblioteke()
        {

            Biblioteka nowaBiblioteka = (Biblioteka)MemberwiseClone();
            nowaBiblioteka.wszystkieKsiazki = new();
            nowaBiblioteka.wypozyczoneKsiazki = new();
            nowaBiblioteka.zgubioneKsiazki = new();
            nowaBiblioteka.dostepneKsiazki = new();


            wszystkieKsiazki.ForEach(wK => nowaBiblioteka.wszystkieKsiazki.Add((Ksiazka)wK.Clone()));
            wypozyczoneKsiazki.ForEach(wyK => nowaBiblioteka.wypozyczoneKsiazki.Add((Ksiazka)wyK.Clone()));
            zgubioneKsiazki.ForEach(zK => nowaBiblioteka.zgubioneKsiazki.Add((Ksiazka)zK.Clone()));
            dostepneKsiazki.ForEach(dK => nowaBiblioteka.dostepneKsiazki.Add((Ksiazka)dK.Clone()));


            return nowaBiblioteka;
        }


        public void ZapisXML(string nazwa)
        {
            using StreamWriter sw = new(nazwa);
            XmlSerializer xs = new(typeof(Biblioteka));
            xs.Serialize(sw, this);
        }

        public static Biblioteka? OdczytXML(string nazwa)
        {
            using StreamReader sr = new(nazwa);
            XmlSerializer xs = new(typeof(Biblioteka));
            return xs.Deserialize(sr) as Biblioteka;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Biblioteka: {NazwaBiblioteki}");
            sb.AppendLine("Książki w bibliotece:");

            foreach (Ksiazka ksiazka in wszystkieKsiazki)
            {
                sb.AppendLine(ksiazka.ToString() + (wypozyczoneKsiazki.Contains(ksiazka) ? "\n(niedostępna)\n" : "\n"));
            }

            sb.AppendLine("Liczba dostępnych książek:");
            sb.AppendLine(LiczbaKsiazek().ToString());


            decimal sumaZgubionych = SumaCen();
            sb.AppendLine($"Łączna kwota należności za zgubione książki: {sumaZgubionych:c}");

            return sb.ToString();
        }
    }
}

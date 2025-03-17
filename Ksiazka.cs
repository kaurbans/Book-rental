using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projekt
{
    public class KsiazkaException : Exception
    {
        public KsiazkaException(string message) : base(message) { }
    }
    public abstract class Ksiazka : ICloneable, IComparable<Ksiazka>, IEquatable<Ksiazka>
    {
        string tytul;
        string autor;
        int rokWydania;
        static decimal oplataZaZgubienie;
        string isbn;
        static int staticID;

        public string Tytul
        {
            get => tytul;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <= 3)
                {
                    throw new KsiazkaException("Tytuł musi mieć więcej niż 3 znaki.");
                }
                tytul = value;
            }
        }

        public string Autor
        {
            get => autor;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <= 5)
                {
                    throw new KsiazkaException("Autor musi mieć więcej niż 5 znaków");
                }
                autor = value;
            }
        }

        public int RokWydania
        {
            get => rokWydania;
            set
            {
                if (value.ToString().Any(c => !char.IsDigit(c)))
                {
                    throw new KsiazkaException("Rok wydania musi składać się wyłącznie z cyfr.");
                }
                rokWydania = value;
            }
        }

        public string ISBN
        {
            get => isbn;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{3}-\d{1}-\d{2}-\d{6}-\d{1}$"))
                {
                    throw new KsiazkaException("ISBN musi mieć format XXX-X-XX-XXXXXX-X.");
                }
                isbn = value;
            }
        }

        static Ksiazka()
        {
            staticID = 1;
            oplataZaZgubienie = 10;
        }

        public Ksiazka()
        {
            isbn = $"{staticID++:000}-0-00-000000-0";
            tytul = string.Empty;
            autor = string.Empty;
            rokWydania = default;
        }

        public Ksiazka(string tytul, string autor, int rokWydania) : this()
        {
            Tytul = tytul;
            Autor = autor;
            RokWydania = rokWydania;
            ISBN = isbn;
        }

        public virtual decimal ObliczCene()
        {
            return oplataZaZgubienie;
        }

        public override string ToString()
        {
            return $"Tytuł: {Tytul} \nAutor: {Autor} \nISBN : {ISBN} \nRok wydania : {RokWydania} \nOpłata za zgubienie : {ObliczCene():c}";
        }

        public object Clone() => MemberwiseClone();

        public int CompareTo(Ksiazka? other) => Tytul.CompareTo(other?.Tytul);

        public bool Equals(Ksiazka? other) => Tytul == other?.Tytul && Autor == other?.Autor;
    }

}

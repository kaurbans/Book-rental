namespace Projekt
{
    public class Program
    {
        static void Main()
        {

            Poradnik p1 = new("Wielka Księga Ogrodnika i Działkowca", "Kawollek Wolfgang", 2022, EnumRodzajPoradnika.Ogrodniczy);


            Poradnik p2 = new("Pomysł na dom", "Katarzyna Czerwińska- Bobocińska", 2024, EnumRodzajPoradnika.Budowlany);


            Poradnik p3 = new("Poradnik fotograficzny", "Hoddinot Ross", 2013, EnumRodzajPoradnika.Fotograficzny);

            Poradnik p4 = new("Poradnik Budowy Kampera", "Miłosz Michalski", 2022, EnumRodzajPoradnika.Budowlany);


            Poradnik p5 = new("Szachy", "Eade James", 2022, EnumRodzajPoradnika.Edukacyjny);


            Powiesc po1 = new("Harry Potter i Kamień Filozoficzny", "J.K. Rowling", 1997, EnumRodzajPowiesci.Fantastyczna);


            Powiesc po2 = new("Władca Pierścieni: Drużyna Pierścienia", "J.R.R. Tolkien", 1954, EnumRodzajPowiesci.Fantastyczna);


            Powiesc po3 = new("Zbrodnia i kara", "Fiodor Dostojewski", 1866, EnumRodzajPowiesci.Psychologiczna);

            Powiesc po4 = new("Przeminęło z wiatrem", "Margaret Mitchell", 1936, EnumRodzajPowiesci.Historyczna);


            Powiesc po5 = new("Rok 1984", "George Orwell", 1949, EnumRodzajPowiesci.Dystopijna);


            Encyklopedia e1 = new("Encyklopedia PWN: Zwierzęta świata", "Redakcja PWN", 2001, "zwierzęta", 3);

            Encyklopedia e2 = new("Encyklopedia wszechświata", "Hubert Reeves", 2018, "kosmos", 2);


            Encyklopedia e3 = new("Encyklopedia sztuki nowoczesnej", "Katarzyna Nowakowska", 2019, "sztuka", 4);


            Encyklopedia e4 = new("Encyklopedia Britannica", "Redakcja Britannica", 2020, "nauka", 1);


            Encyklopedia e5 = new("Encyklopedia roślin", "Jane Goodall", 2003, "flora", 2);


            Podrecznik pod1 = new("Matematyka 2. Podręcznik dla liceum", "Marek Nowicki", 2021, "Matematyka", EnumPoziomEdukacji.Liceum);


            Podrecznik pod2 = new("Historia Polski dla licealistów", "Andrzej Chwalba", 2019, "Historia", EnumPoziomEdukacji.Liceum);


            Podrecznik pod3 = new("Chemia. Zbiór zadań", "Maria Litwin", 2017, "Chemia", EnumPoziomEdukacji.Gimnazjum);


            Podrecznik pod4 = new("Biologia na czasie 1", "Franciszek Dubert", 2019, "Biologia", EnumPoziomEdukacji.Liceum);

            Podrecznik pod5 = new("Zrozumieć fizykę", "Marcin Braun", 2022, "Fizyka", EnumPoziomEdukacji.Liceum);

            Biografia b1 = new("Messi. Biografia", "Guillem Balague", 2014, "Lionel Messi");

            Biografia b2 = new("Steve Jobs", "Walter Isaacson", 2011, "Steve Jobs");


            Biografia b3 = new("Gandhi: A Life", "Krishna Kripalani", 1960, "Mahatma Gandhi");


            Biografia b4 = new("Maria Curie", "Eve Curie", 1937, "Maria Skłodowska-Curie");


            Biografia b5 = new("Churchill", "Andrew Roberts", 2018, "Winston Churchill");



            Biblioteka biblioteka = new Biblioteka("Biblioteka Miejska");

            biblioteka.DodajKsiazke(p1);
            biblioteka.DodajKsiazke(p2);
            biblioteka.DodajKsiazke(p3);
            biblioteka.DodajKsiazke(p4);
            biblioteka.DodajKsiazke(p5);

            biblioteka.DodajKsiazke(po1);
            biblioteka.DodajKsiazke(po2);
            biblioteka.DodajKsiazke(po3);
            biblioteka.DodajKsiazke(po4);
            biblioteka.DodajKsiazke(po5);

            biblioteka.DodajKsiazke(e1);
            biblioteka.DodajKsiazke(e2);
            biblioteka.DodajKsiazke(e3);
            biblioteka.DodajKsiazke(e4);
            biblioteka.DodajKsiazke(e5);

            biblioteka.DodajKsiazke(pod1);
            biblioteka.DodajKsiazke(pod2);
            biblioteka.DodajKsiazke(pod3);
            biblioteka.DodajKsiazke(pod4);
            biblioteka.DodajKsiazke(pod5);

            biblioteka.DodajKsiazke(b1);
            biblioteka.DodajKsiazke(b2);
            biblioteka.DodajKsiazke(b3);
            biblioteka.DodajKsiazke(b4);
            biblioteka.DodajKsiazke(b5);



            biblioteka.ZapisXML("biblioteka.xml");


            Biblioteka wczytanaBiblioteka = Biblioteka.OdczytXML("biblioteka.xml");
            Console.WriteLine("Odczytana biblioteka to: \n" + wczytanaBiblioteka.ToString());



            
            Console.WriteLine("=== Klonowanie książki ===");

            Powiesc po1kopia = (Powiesc)po1.Clone();

            Console.WriteLine("Oryginał:");
            Console.WriteLine(po1);

            Console.WriteLine("\nKlon:");
            Console.WriteLine(po1kopia);

            Console.WriteLine("\nCzy oryginał i klon są równe? " + po1.Equals(po1kopia) +"\n");


            Console.WriteLine("=== Klonowanie biblioteki ===");

            Biblioteka kopiaBiblioteki = biblioteka.KopiujBiblioteke();

            Console.WriteLine("Oryginalna Biblioteka:");
            Console.WriteLine(biblioteka);

            Console.WriteLine("Sklonowana Biblioteka:");
            Console.WriteLine(kopiaBiblioteki);






            Console.WriteLine("=== Wszystkie książki w bibliotece ===");
            Console.WriteLine(biblioteka);


            Console.WriteLine("=== Sprawdzamy kategorie książek ===");
            biblioteka.WyswietlKategorie();

            Console.WriteLine("\n=== Książki w kategorii 'wszystkie' ===");
            foreach (Ksiazka ksiazka in biblioteka.WyswietlKsiazkiWedlugKategorii("Wszystkie"))
            {
                Console.WriteLine(ksiazka); 
            }


            Console.WriteLine("\n=== Wypożyczanie książki ===");
            biblioteka.WypozyczKsiazke(p1);
            biblioteka.WypozyczKsiazke(e1); 

        
            Console.WriteLine("\n=== Wypożyczone książki ===");
            biblioteka.WyswietlWypozyczoneKsiazki();


            Console.WriteLine("\n=== Książki w kategorii 'poradnik' ===");
            foreach (Ksiazka ksiazka in biblioteka.WyswietlKsiazkiWedlugKategorii("Poradnik"))
            {
                Console.WriteLine(ksiazka); 
            }


            Console.WriteLine("\n=== Zwracanie książki ===");
            biblioteka.ZwrocKsiazke(e1.ISBN,true);

         
            Console.WriteLine("\n=== Aktualnie wypożyczone książki ===");
            biblioteka.WyswietlWypozyczoneKsiazki();

            Console.WriteLine("\n=== Książki zgubione ===");
            biblioteka.WyswietlZgubioneKsiazki();



            Console.WriteLine("\n=== Wszystkie książki po zwróceniu ===");
            Console.WriteLine(biblioteka);



            Console.WriteLine("\n=== Wszystkie książki po sortowaniu ===");
            biblioteka.SortujKsiazki();
            Console.WriteLine(biblioteka);





            



        }

    }
}
using Projekt;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt__GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Biblioteka b;
        private Ksiazka wybranaKsiazka;
        public MainWindow()
        {
            InitializeComponent();
            ZaladujBiblioteke();
        }

        private void ZaladujBiblioteke()
        {
            b = new Biblioteka();
            b = Biblioteka.OdczytXML("../../../../biblioteka.xml");
            OdswiezListeKsiazek();
        }

        private void OdswiezListeKsiazek(string kategoria = null)
        {
            ListaKsiazek.ItemsSource = null;

            if (!string.IsNullOrEmpty(kategoria))
            {
                ListaKsiazek.ItemsSource = b.WyswietlKsiazkiWedlugKategorii(kategoria);
            }
            else
            {
                ListaKsiazek.ItemsSource = b.DostepneKsiazki;
                //TytulTabeliTextBox.Text = "Dostępne książki";
            }

            ListaKsiazek.DisplayMemberPath = "Tytul"; //tylko tytuły
        }
        private void ListaKsiazek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybranaKsiazka = (Ksiazka)ListaKsiazek.SelectedItem;
            if (wybranaKsiazka != null)
            {
                SzczegolyTextBox.Text = wybranaKsiazka.ToString();
            }
        }

        private void WypozyczButton_Click(object sender, RoutedEventArgs e)
        {
            if (wybranaKsiazka != null)
            {
                SzczegolyTextBox.Text = "Książka wypożyczona:\n " + wybranaKsiazka;
                b.WypozyczKsiazke(wybranaKsiazka);
                ComboBoxItem selectedItem = (ComboBoxItem)KategoriaComboBox.SelectedItem;
                string kategoria = selectedItem?.Content.ToString();
                OdswiezListeKsiazek(kategoria);
            }
            else
            {
                MessageBox.Show("Wybierz książkę do wypożyczenia.");
            }
            KwotaDoZaplatyTextBox.Text = null;
        }

        private void OddajButton_Click(object sender, RoutedEventArgs e)
        {
            KategoriaComboBox.SelectedIndex = -1;
            string isbn = OddajTextBox.Text;
            Ksiazka ksiazkaDoZwrotu = b.WypozyczoneKsiazki.Find(k => k.ISBN == isbn);

            if (ksiazkaDoZwrotu != null && !b.DostepneKsiazki.Contains(ksiazkaDoZwrotu))
            {
                b.ZwrocKsiazke(ksiazkaDoZwrotu.ISBN , false);
                SzczegolyTextBox.Text = "Książka zwrócona:\n " + ksiazkaDoZwrotu;
                OdswiezListeKsiazek();
            }
            else
            {
                MessageBox.Show("Nie znaleziono książki do zwrotu lub jest już dostępna.");
            }
            OddajTextBox.Text = null;
        }
        private void ZglosButton_Click(object sender, RoutedEventArgs e)
        {
            KategoriaComboBox.SelectedIndex = -1;
            string isbn = OddajTextBox.Text;
            Ksiazka ksiazkaDoZwrotu = b.WypozyczoneKsiazki.Find(k => k.ISBN == isbn);

            if (ksiazkaDoZwrotu != null && !b.DostepneKsiazki.Contains(ksiazkaDoZwrotu))
            {
                b.ZwrocKsiazke(ksiazkaDoZwrotu.ISBN, true);
                SzczegolyTextBox.Text = "Książka zwrócona:\n " + ksiazkaDoZwrotu;
                OdswiezListeKsiazek();
                KwotaDoZaplatyTextBox.Text = $"{ksiazkaDoZwrotu.ObliczCene():c}";
                DoZaplatyTextBox.Text = "Jednostkowa kwota do zapłaty";
            }
            else
            {
                MessageBox.Show("Nie znaleziono książki do zwrotu lub jest już dostępna.");
            }
            OddajTextBox.Text = null;
        }


        private void AZButton_Click(object sender, RoutedEventArgs e)
        {
            b.SortujKsiazki();
            ComboBoxItem selectedItem = (ComboBoxItem)KategoriaComboBox.SelectedItem;
            string kategoria = selectedItem?.Content.ToString();
            OdswiezListeKsiazek(kategoria);
        }

        private void Wypozyczone_Click(object sender, RoutedEventArgs e)
        {
            KategoriaComboBox.SelectedIndex = -1;
            KwotaDoZaplatyTextBox.Text = null;
            DoZaplatyTextBox.Text = null;
            ListaKsiazek.ItemsSource = b.WypozyczoneKsiazki;
            TytulTabeliTextBox.Text = "Wypożyczone książki";
        }

        private void Zgubione_Click(object sender, RoutedEventArgs e)
        {
            KategoriaComboBox.SelectedIndex = -1;
            KwotaDoZaplatyTextBox.Text = null;
            KwotaDoZaplatyTextBox.Text = $"{b.SumaCen():c}";                     
            ListaKsiazek.ItemsSource = b.ZgubioneKsiazki;
            TytulTabeliTextBox.Text = "Zgubione książki";
            DoZaplatyTextBox.Text = "Całkowita kwota do zapłaty";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KwotaDoZaplatyTextBox.Text = null;
            DoZaplatyTextBox.Text = null;
            ComboBoxItem selectedItem = (ComboBoxItem)KategoriaComboBox.SelectedItem;
            string kategoria = selectedItem?.Content.ToString();

            ListaKsiazek.ItemsSource = b.WyswietlKsiazkiWedlugKategorii(kategoria);
            TytulTabeliTextBox.Text = $"Dostępne książki z kategorii: {kategoria}";
        }
    }
}
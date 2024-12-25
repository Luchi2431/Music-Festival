using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace muzickifestivali
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string usernameAdmin = "admin";
        string passwordAdmin = "admin";
        string usernameKorisnik = "korisnik";
        string passwordKorisnik = "korisnik";
        string korisnik;
        List<string> rtfList = new List<string>();

        private ObservableCollection<Data> kolekcija = new ObservableCollection<Data>();

        internal ObservableCollection<Data> Kolekcija { get => kolekcija; set => kolekcija = value; }

        public MainWindow()
        {
            LoadData("muzickifestivali.bin");

            if (Kolekcija == null)
            {
                Kolekcija = new ObservableCollection<Data>();
            }
            DataContext = this;
            InitializeComponent();

            dataGridData.ItemsSource = Kolekcija;
            
        }
        private void LoadData(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    if (fileStream != null && fileStream.Length != 0 && fileStream.Position != fileStream.Length)
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        Kolekcija = (ObservableCollection<Data>)binaryFormatter.Deserialize(fileStream);
                    }
                }
            }
        }

        public void SaveData(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, Kolekcija);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void korisnickoIme_LostFocus(object sender, RoutedEventArgs e)
        {
            if (korisnickoIme.Text.Trim() == "")
            {
                tbUsernameError.Text = "Ovo polje je obavezno";
                korisnickoIme.Text = "Unesite ime";
            }
        }

        private void korisnickoIme_GotFocus(object sender, RoutedEventArgs e)
        {
            if (korisnickoIme.Text == "Unesite ime")
            {
                korisnickoIme.Text = "";
                tbUsernameError.Text = "";

            }
        }

        private void lozinka_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lozinka.Password == "")
            {
                tbPasswordError.Text = "";
            }
        }
        private void lozinka_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lozinka.Password.Trim() == "")
            {
                tbPasswordError.Text = "Ovo polje je obavezno";
            }
        }



        private void prijava_Click(object sender, RoutedEventArgs e)
        {
            if (korisnickoIme.Text.Trim() == "" || korisnickoIme.Text == "Korisničko ime" || lozinka.Password.Length == 0)
            {
                MessageBox.Show("Morate uneti sve podatke za prijavu", "Nepotpun unos podataka", MessageBoxButton.OK, MessageBoxImage.Error);
                if (korisnickoIme.Text == "Korisničko ime")
                {
                    tbUsernameError.Text = "Ovo polje je obavezno";    
                }
                if (lozinka.Password == "")
                {
                    tbPasswordError.Text = "Ovo polje je obavezno";                 
                }
            }
            else
            {

                if (korisnickoIme.Text.ToLower() == usernameAdmin && lozinka.Password == passwordAdmin)
                {
                    korisnik = usernameAdmin;
                    
                    loginGrid.Visibility = Visibility.Hidden;
                    loggedGrid.Visibility = Visibility.Visible;
                    lblUser.Content = "Admin";
                    tabela.Visibility = Visibility.Visible;
                    btnDodaj.IsEnabled = true;
                    btnIzbrisi.IsEnabled = true;
                }
                else if (korisnickoIme.Text.ToLower() == usernameKorisnik && lozinka.Password == passwordKorisnik)
                {
                    korisnik = usernameKorisnik;
                    
                    loginGrid.Visibility = Visibility.Hidden;
                    loggedGrid.Visibility = Visibility.Visible;
                    lblUser.Content = "Korisnik";
                    tabela.Visibility = Visibility.Visible;
                    btnDodaj.IsEnabled = false;
                    btnIzbrisi.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("Greška! Podaci za prijavu nisu validni!", "Unos neispravnih podataka", MessageBoxButton.OK, MessageBoxImage.Error);
                    korisnickoIme.Clear();
                    lozinka.Clear();
                }
            }

        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            dodavanje novoDodavanje = new dodavanje();
            novoDodavanje.ShowDialog();

            if(novoDodavanje.uspesno == true)
            {
                Kolekcija.Add(new Data(int.Parse(novoDodavanje.tbGodina.Text), novoDodavanje.tbNaziv.Text, novoDodavanje.dodajSliku.Source.ToString(), novoDodavanje.naziv, DateTime.Now));
                dataGridData.ItemsSource = Kolekcija;
            }

        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            for (int i = Kolekcija.Count - 1; i >= 0; i--)
            {
                if (Kolekcija[i].IsSelected == true)
                {
                    rtfList.Add(Kolekcija[i].Datoteka);
                    Kolekcija.RemoveAt(i);
                }
            }

            foreach (string s in rtfList)
            {
                if (File.Exists(s))
                {
                    try
                    {
                        File.Delete(s);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška pri brisanju " + ex.Message, "Greška", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
            }

        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            loggedGrid.Visibility = Visibility.Hidden;
            loginGrid.Visibility = Visibility.Visible;
            lozinka.Clear();
            tabela.Visibility = Visibility.Hidden;

        }


        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SaveData("muzickifestivali.bin");
        }

        private void izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void hyperlink_Clicked(object sender, RoutedEventArgs e)
        {
            Data kol = Kolekcija[dataGridData.SelectedIndex];

            if (korisnik == usernameAdmin)
            {
                dodavanje novoDodavanje = new dodavanje();
                novoDodavanje.btnDodaj.Content = "Izmena";
                novoDodavanje.tbGodina.Text = kol.godina.ToString();
                novoDodavanje.tbNaziv.Text = kol.Naziv.ToString();
                TextRange textRange;
                FileStream fileStream;
                Uri uri = new Uri(kol.Slika);
                novoDodavanje.dodajSliku.Source = new BitmapImage(uri);
                

                if (File.Exists(kol.Datoteka))
                {
                    textRange = new TextRange(novoDodavanje.rtbTekst.Document.ContentStart, novoDodavanje.rtbTekst.Document.ContentEnd);
                    using (fileStream = new System.IO.FileStream(kol.Datoteka, System.IO.FileMode.OpenOrCreate))
                    {
                        textRange.Load(fileStream, DataFormats.Rtf);
                    }
                }
                novoDodavanje.ShowDialog();
                Kolekcija[dataGridData.SelectedIndex] = new Data(int.Parse(novoDodavanje.tbGodina.Text), novoDodavanje.tbNaziv.Text, novoDodavanje.dodajSliku.Source.ToString(), novoDodavanje.naziv, DateTime.Now);
                dataGridData.ItemsSource = Kolekcija;
            }
            else if (korisnik == usernameKorisnik)
            {
                Prikaz prikaz = new Prikaz();
                prikaz.tbPrikazGodina.Text = kol.godina.ToString();
                prikaz.tbPrikazNaziva.Text = kol.Naziv.ToString();
                prikaz.tbPrikazDatuma.Text = kol.Datum.ToString();

                Uri uri = new Uri(kol.Slika);
                prikaz.PrikazSlika.Source = new BitmapImage(uri);
                TextRange textRange;
                FileStream fileStream;

                if (File.Exists(kol.Datoteka))
                {
                    textRange = new TextRange(prikaz.rtbPrikaz.Document.ContentStart, prikaz.rtbPrikaz.Document.ContentEnd);
                    using (fileStream = new System.IO.FileStream(kol.Datoteka, System.IO.FileMode.OpenOrCreate))
                    {
                        textRange.Load(fileStream, DataFormats.Rtf);
                    }
                }
                prikaz.ShowDialog();
            }
        }

    }
}

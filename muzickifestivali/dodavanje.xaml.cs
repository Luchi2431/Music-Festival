using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace muzickifestivali
{
    /// <summary>
    /// Interaction logic for dodavanje.xaml
    /// </summary>
    public partial class dodavanje : Window
    {
        public string pomocna = "";
        public string naziv;
        public bool uspesno;
        public bool izmena;
        private List<string> ChosenColors;
        string tempFile;

        public dodavanje()
        {
            InitializeComponent();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);

            for (int i = 1; i < 100; i++)
            {
                cmbSize.Items.Add(i.ToString());
            }

            cmbSize.SelectedItem = "10";
            cmbFontFamily.SelectedIndex = 4;
            cmbFontColor.SelectedItem = "Black";
            ChosenColors = new List<string>();

            for (int i = 0; i < (typeof(Colors).GetProperties().Count()); i++)
            {
                cmbFontColor.Items.Add(typeof(Colors).GetProperties()[i].ToString().Split(' ')[1]);
            }

            object temp = rtbTekst.Selection.GetPropertyValue(Inline.ForegroundProperty);
            cmbFontColor.SelectedItem = GetColor((SolidColorBrush)(new BrushConverter().ConvertFrom(temp.ToString())));

            
        }

        private void tbGodina_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbGodina.Text == "Unesite godinu")
            {
                tbGodina.Text = "";
                tbGodinaError.Text = "";
            }
        }

        private void tbGodina_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbGodina.Text.Trim() == "")
            {
                tbGodina.Text = "Unesite godinu";
                tbGodinaError.Text = "Ovo polje je obavezno";
            }
        }

        private void tbNaziv_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbNaziv.Text == "Unesite naziv")
            {
                tbNaziv.Text = "";
                tbNazivError.Text = "";
            }

        }

        private void tbNaziv_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbNaziv.Text.Trim() == "")
            {
                tbNaziv.Text = "Unesite naziv";
                tbNazivError.Text = "Ovo polje je obavezno";
            }
        }




        private void tbNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbTekst.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = rtbTekst.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));

            temp = rtbTekst.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtbTekst.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;

            temp = rtbTekst.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbSize.Text = temp.ToString();

            temp = rtbTekst.Selection.GetPropertyValue(Inline.ForegroundProperty);

        }

        private void rtbEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountWords();

        }
        private void CountWords()
        {
            int count = 0;
            int index = 0;
            string richText = new TextRange(rtbTekst.Document.ContentStart, rtbTekst.Document.ContentEnd).Text;

            while (index < richText.Length && char.IsWhiteSpace(richText[index]))
            {
                index++;
            }

            while (index < richText.Length)
            {
                while (index < richText.Length && !char.IsWhiteSpace(richText[index]))
                    index++;

                count++;

                while (index < richText.Length && char.IsWhiteSpace(richText[index]))
                    index++;

            }
            tbStatus.Text = count.ToString();

        }

        private void cmbSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSize.SelectedValue != null && !rtbTekst.Selection.IsEmpty)
            {
                rtbTekst.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbSize.SelectedValue);
            }

        }

        private void cmbFontColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontColor.SelectedItem != null)
            {
                rtbTekst.Selection.ApplyPropertyValue(Inline.ForegroundProperty, (SolidColorBrush)(new BrushConverter().ConvertFrom(cmbFontColor.SelectedValue.ToString())));
                if (!ChosenColors.Contains(cmbFontColor.SelectedValue.ToString()))
                {
                    ChosenColors.Add(cmbFontColor.SelectedValue.ToString());
                }
            }

        }

        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null && !rtbTekst.Selection.IsEmpty)
            {
                rtbTekst.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }

        }

        private string GetColor(SolidColorBrush brush)
        {
            string result = string.Empty;

            SolidColorBrush stringBrush = null;

            foreach (string s in ChosenColors)
            {
                stringBrush = ((SolidColorBrush)(new BrushConverter().ConvertFrom(s)));

                if ((stringBrush.Color.A == brush.Color.A) && (stringBrush.Color.R == brush.Color.R) && (stringBrush.Color.G == brush.Color.G) && (stringBrush.Color.B == brush.Color.B))
                {
                    result = s;
                }
            }

            return result;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                naziv = "";
                naziv = tbNaziv.Text + ".rtf";

                tempFile = naziv;

                TextRange textRange;
                FileStream fileStream;
                textRange = new TextRange(rtbTekst.Document.ContentStart, rtbTekst.Document.ContentEnd);
                fileStream = new FileStream(naziv, FileMode.Create);
                textRange.Save(fileStream, DataFormats.Rtf);
                fileStream.Close();
                this.Close();
                uspesno = true;
            }
            else
            {
                uspesno = false;
            }

        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDodajSliku_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                pomocna = openFileDialog.FileName;
                Uri uri = new Uri(pomocna);
                dodajSliku.Source = new BitmapImage(uri);
                tbImageError.Visibility = Visibility.Hidden;
               
            }
        }

        private bool validate()
        {
            if (tbGodina.Text.Trim() == "" || tbNaziv.Text.Trim() == "" || dodajSliku.Source == null || tbGodina.Text == "Unesite godinu" || tbNaziv.Text == "Unesite naziv")
            {
                MessageBox.Show("Morate uneti sve podatke", "Greška prilikom unosa", MessageBoxButton.OK, MessageBoxImage.Error);
                if (tbGodina.Text == "" || tbGodina.Text == "Unesite godinu")
                {
                    tbGodinaError.Text = "Ovo polje je obavezno";

                }
                if (tbNaziv.Text == "" || tbNaziv.Text == "Unesite naziv")
                {
                    tbNazivError.Text = "Ovo polje je obavezno";

                }
                if (dodajSliku.Source == null)
                {
                    tbImageError.Visibility = Visibility.Visible;
                }
                return false;
            }
            if (!double.TryParse(tbGodina.Text, out double result))
            {
                MessageBox.Show("Godina mora biti brojevni tip podatka", "Loš tip podatka", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (double.Parse(tbGodina.Text) <= 0)
            {
                MessageBox.Show("Godina mora biti ne negativan broj");
                return false;
            }


            return true;
        }
    }
}

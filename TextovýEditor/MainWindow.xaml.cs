using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextovýEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = "";
        public MainWindow()
        {
            InitializeComponent();
        }

  private void btnwrite_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog()
            {
                Filter = "txt soubory (*.txt)|*.txt",
                Title = "otevřít TXT soubor"
            };
            if (OD.ShowDialog() == true)
            {
                path = OD.FileName;
                btnwrite.IsEnabled = true;

                precit(path);
            }
        }


        private void precit(string path)
        {
            textvystup.Text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string radek;
                while ((radek = sr.ReadLine()) != null)
                {
                    textvystup.Text += radek + "\n";
                    textvystup.Text += {Binding Path=DateTimeValue, StringFormat= dd/MM/YYYY - hh:mm:ss};
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string vstup = textvstup.Text;
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write($"{vstup}\n");
            }
            if (string.IsNullOrEmpty(textvstup.Text)) 
            {
                Popup popup = new Popup();
                
            }
            textvstup.Text = "";
            precit(path);
        }

      
    }
}

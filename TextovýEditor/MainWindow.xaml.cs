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
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string vstup = textvstup.Text;
            DateTime cas = DateTime.Now;
            string Casik = cas.ToString().Replace(" "," - ").Replace(".","/");
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    if (vstup.Length == 0)
                    {
                        // Novy okno kdyz si kokot a text
                        Window1 newWindow = new Window1();

                        newWindow.Show();
                    }
                    else
                    {
                        sw.Write($"{vstup} | {Casik}\n");
                    }

                }
                textvstup.Text = "";
                precit(path);
            } catch (Exception ex)
            {
                // Novy okno kdyz si kokot a nemas soubor
                Window1 newWindow = new Window1();

                newWindow.Show();
            }
            
        }

      
    }
}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Inlämning_1
{
    public partial class MainWindow : Window
    {

        public AnimalCollection animalCol = new AnimalCollection();
        
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ComboBox cmb = (ComboBox)typeComboBox;
            ComboBoxItem dogOrCat = (ComboBoxItem)cmb.SelectedItem;
            bool isDog = true;
            if (dogOrCat.Content.ToString() == "Cat")
            {
                isDog = false;
            }
            animalCol.createAnimal(regBox, isDog, descBox.Text, raceBox.Text);

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            List<String> strList = new List<String>();
            var animalList = animalCol.animalList;

            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "Text (*.csv)|*.csv";
            saveFileDialog1.FileName = "Animallist.csv";
            saveFileDialog1.ShowDialog();
            StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());
            for (int i = 0; i < animalList.Count; i++)
            {
                String dogOrCat = "cat";
                if (animalList[i].isDog)
                {
                    dogOrCat = "Dog";
                }
                String tempstr = "regNr:" + animalList[i].regNr + ", race:" + animalList[i].race + ", description:" + animalList[i].description + ", type:" + dogOrCat;
                writer.WriteLine(tempstr);
            }
            writer.Dispose();
            writer.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}

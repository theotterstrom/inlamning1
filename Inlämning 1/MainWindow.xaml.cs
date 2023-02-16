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
using System.Collections.Specialized;
using AnimalClasses;
using System.Collections.ObjectModel;
using System.Threading;

namespace Inlämning_1
{
    public partial class MainWindow : Window
    {   
        public ObservableCollection<Animal> animalList { get; set; } = new ObservableCollection<Animal>();
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            regBox.SelectionChanged += RegBox_SelectionChanged;
            readFile();
            Thread.Sleep(1000);
        }

        private void RegBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)regBox;
            ComboBoxItem selRegBoxItem = (ComboBoxItem)cmb.SelectedItem;
            if(selRegBoxItem != null)
            {
                string selRegNr = selRegBoxItem.Content.ToString();
                foreach (Animal an in animalList)
                {
                    if (an.regNr == selRegNr)
                    {
                        raceBox.Text = an.race;
                        descBox.Text = an.description;
                        if (an.isDog)
                        {
                            typeComboBox.SelectedItem = dawg;
                        }
                        else
                        {
                            typeComboBox.SelectedItem = pussycat;
                        }
                        break;
                    }
                }
            }
            else
            {
                descBox.Text = "";
                raceBox.Text = "";
                typeComboBox.SelectedIndex = -1;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool redundant = false;
            foreach(Animal an in animalList)
            {
                if(an.regNr == regBox.Text)
                {
                    redundant = true;
                }
            }
            var checkFields = regBox.Text == "" || descBox.Text == "" || raceBox.Text == "" || typeComboBox.SelectedItem == null;
            if (checkFields)
            {
                string tstr = "Fill all fields!";
                MessageBox.Show(tstr);
            }
            else if (redundant)
            {
                string tstr = "Registration number already taken!";
                MessageBox.Show(tstr);
            }
            else
            {
                ComboBox cmb = (ComboBox)typeComboBox;
                ComboBoxItem dogOrCat = (ComboBoxItem)cmb.SelectedItem;
 
                if (dogOrCat.Content.ToString() == "Cat")
                {
                    Cat tempcat = new Cat();
                    tempcat.regNr = regBox.Text;
                    tempcat.description = descBox.Text;
                    tempcat.race = raceBox.Text;
                    animalList.Add(tempcat);
                }
                else
                {
                    Dog tempdog = new Dog();
                    tempdog.regNr = regBox.Text;
                    tempdog.description = descBox.Text;
                    tempdog.race = raceBox.Text;
                    animalList.Add(tempdog);
                }
                regBox.Text = "";
                descBox.Text = "";
                raceBox.Text = "";
                cmb.SelectedIndex = -1;
            }  
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            List<String> strList = new List<String>();

            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "Text (*.csv)|*.csv";
            saveFileDialog1.FileName = "Animallist.csv";
            saveFileDialog1.ShowDialog();
            StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());
            
            for (int i = 0; i < animalList.Count; i++)
            {
                String dogOrCat = "Cat";
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

        private void readFile()
        {
            string filepath = "../../../Animallist.csv";
            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] words = line.Split(',');
                    
                    bool isDog = true;
                    if(words.Length > 1)
                    {
                        if (words[3].Split(':')[1] == "Cat")
                        {
                            isDog = false;
                        }

                        Animal animal = new Animal()
                        {
                            regNr = words[0].Split(':')[1],
                            race = words[1].Split(':')[1],
                            description = words[2].Split(':')[1],
                            isDog = isDog
                        };
                        animalList.Add(animal);
                    }
                }
            }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

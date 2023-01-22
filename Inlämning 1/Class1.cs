using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace Inlämning_1
{
    public class AnimalCollection
    {
        public ObservableCollection<Animal> animalList;

        public void createAnimal(ComboBox regBox, Boolean isDog, String descBox, String raceBox)
        {
            Animal tempan = new Animal()
            {
                regNr = regBox.Text,
                race = raceBox,
                description = descBox,
                isDog = isDog

            };

            /*ComboBoxItem tempItem = new ComboBoxItem();
            tempItem.Content = tempan.regNr;
            regBox.Items.Add(tempItem);*/

            animalList.Add(tempan);
            
            regBox.DataContext = animalList;
            regBox.DisplayMemberPath = "name";
        }
       
    }

        public class Animal : AnimalCollection
        {
            public String regNr { get; set; }
            public String race { get; set; }
            public String description { get; set; }
            public bool isDog { get; set; }
        }
    }


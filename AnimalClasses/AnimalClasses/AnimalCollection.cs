using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClasses
{
    public class AnimalCollection
    {
        public ObservableCollection<Animal> animalList = new ObservableCollection<Animal>();

        public void createAnimal(String regBox, Boolean isDog, String descBox, String raceBox)
        {
            Animal tempan = new Animal()
            {
                regNr = regBox,
                race = raceBox,
                description = descBox,
                isDog = isDog

            };
            animalList.Add(tempan);
        }
    }
}

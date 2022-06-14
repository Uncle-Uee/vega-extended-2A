using System.Collections.Generic;
using UnityEngine;

namespace Tricks
{
    public class Farm : MonoBehaviour
    {
        [Header("Polymorphic Animals")]
        [SerializeReference]
        public List<Animal> PolymorphicFarmAnimals = new List<Animal>();

        [Header("Non Polymorphic Animals")]
        public List<Animal> NonPolymorphicAnimals = new List<Animal>();

        public void AddCow(bool isPoly = false)
        {
            if (isPoly) PolymorphicFarmAnimals.Add(new Cow());
            else NonPolymorphicAnimals.Add(new Cow());
        }

        public void AddSheep(bool isPoly = false)
        {
            if (isPoly) PolymorphicFarmAnimals.Add(new Sheep());
            else NonPolymorphicAnimals.Add(new Sheep());
        }

        public void AddDuck(bool isPoly = false)
        {
            if (isPoly) PolymorphicFarmAnimals.Add(new Duck());
            else NonPolymorphicAnimals.Add(new Duck());
        }
    }
}
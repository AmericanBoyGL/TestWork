using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace MenuScene.AnimalIcon
{
    public class IconAnimalModel
    {
        private Sprite imageAnimalIcon;
        private AnimalNames animalName;

        public Sprite ImageAnimalIcon => imageAnimalIcon;
        public AnimalNames AnimalName => animalName;

        public void SetImageAnimal(AnimalNames name, Sprite img)
        {
            imageAnimalIcon = img;
            animalName = name;  
        }
    }
}


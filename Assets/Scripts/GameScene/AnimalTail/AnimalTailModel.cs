using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

namespace GameScene.AnimalTail
{
    public class AnimalTailModel : MonoBehaviour
    {
        private Sprite imageAnimalIcon;
        private AnimalNames animalName;
        private bool isCorrectTail;
        private AnimalSpineController animalSpineController;
        public Action onClickTail;
        
        public Sprite ImageAnimalIcon => imageAnimalIcon;
        public AnimalNames AnimalName => animalName;
        public bool IsCorrectTail => isCorrectTail;
        public AnimalSpineController AnimalSpineController => animalSpineController;
        
        public void SetParamsAnimal(AnimalNames name, Sprite img, AnimalSpineController animalSpine, bool isCorrect)
        {
            imageAnimalIcon = img;
            animalName = name;
            isCorrectTail = isCorrect;
            animalSpineController = animalSpine;
        }
    }
}

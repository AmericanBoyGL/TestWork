using System;
using System.Collections;
using System.Collections.Generic;
using GameScene;
using MenuScene.AnimalIcon;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace MenuScene
{
    public class PreloadGenerationIcons : MonoBehaviour
    {
        [Serializable]
        public struct AnimalIcon {
            public AnimalNames animalName;
            public Sprite animalIconSprite;
        }
        
        [SerializeField] private List<AnimalIcon> _iconsAnimals;
        [SerializeField] private IconAnimalController _iconAnimalPrefab;
        [SerializeField] private Transform _placeToGeneration;

        private void Awake()
        {
            GenerationIconsBtn();
        }

        private void GenerationIconsBtn()
        {
            foreach (var icon in _iconsAnimals)
            {
                var animal = Instantiate<IconAnimalController>(_iconAnimalPrefab, _placeToGeneration);
                animal.InitAnimal(icon.animalName, icon.animalIconSprite);
            }
        }

        public int GetCountIcons()
        {
            return _iconsAnimals.Count;
        }
    }
}


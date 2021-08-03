using System;
using System.Collections;
using System.Collections.Generic;
using GameScene.AnimalTail;
using MenuScene;
using ScriptableObj;
using Scripts;
using Spine;
using Spine.Unity;
using Spine.Unity.Editor;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameScene
{
    public class PreloadGenerationLevel : MonoBehaviour
    {
        [Serializable]
        public struct Animal {
            public AnimalNames animalName;
            public AnimalSpineController animalPrefab;
            public Sprite tailImg;
            public AudioClip welcomeVoice;
        }
        
        [SerializeField] private List<Animal> _animalsPref;
        [SerializeField] private AnimalTailController animalTailController;
        [SerializeField] private InactivityController _inactivityController;
        [SerializeField] private ShareDataForScenes _shareData;
        [SerializeField] private Transform _spawnAnimalArea;
        [SerializeField] private RectTransform _spawnTrailAreaLeft;
        [SerializeField] private List<Transform> _areasForTails;
        [SerializeField] private Button _animalBtn;
        
        private AnimalSpineController correctAnimal;
        private void Awake()
        {
            correctAnimal = new AnimalSpineController();
            SpawnCorrectAnimal();
            InitializeTail(correctAnimal);
        }

        private void SpawnCorrectAnimal()
        {
            for (int i = 0; i < _animalsPref.Count; i++)
            {
                if (_shareData.loadAnimalByName == _animalsPref[i].animalName)
                {
                    var animal = Instantiate(_animalsPref[i].animalPrefab, _spawnAnimalArea);
                    animal.Init(_animalsPref[i].welcomeVoice, _animalBtn);
                    correctAnimal = animal;
                }
            }
        }

        private void InitializeTail(AnimalSpineController correctAnimal)
        {
            for (int i = 0; i < _animalsPref.Count; i++)
            {
                if (_shareData.loadAnimalByName == _animalsPref[i].animalName)
                    SpawnTailsInArea(_animalsPref[i], i, correctAnimal, true);
                else
                    SpawnTailsInArea(_animalsPref[i], i, correctAnimal);
            }
        }

        private void SpawnTailsInArea(Animal animal, int index, AnimalSpineController animalSpine, bool isCorrect = false)
        {
            var trail = Instantiate(animalTailController, _areasForTails[index]);
            trail.InitAnimal(animal.animalName, animal.tailImg, animalSpine, isCorrect);
            _inactivityController.AddTailToList(trail);
        }
    }
}

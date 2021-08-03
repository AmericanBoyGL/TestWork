using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace MenuScene.AnimalIcon
{
    public class IconAnimalController : MonoBehaviour
    {
        [SerializeField] private IconAnimalView iconAnimalView;
        private IconAnimalModel _model;

        private void Awake()
        {
            _model = new IconAnimalModel();   
        }

        public void InitAnimal(AnimalNames name, Sprite img)
        {
            _model.SetImageAnimal(name, img);
            iconAnimalView.Init(_model);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObj;
using Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MenuScene.AnimalIcon
{
    public class IconAnimalView : MonoBehaviour
    {
        [SerializeField] private Image _iconAnimal;
        [SerializeField] private Button _iconBtn;
        [SerializeField] private ShareDataForScenes _shareData;
        
        private IconAnimalModel _model;

        private void Awake()
        {
            _iconBtn.onClick.AddListener(SetLevel);
        }

        public void Init(IconAnimalModel model)
        {
            _model = model;
            _iconAnimal.sprite = _model.ImageAnimalIcon;
        }

        private void SetLevel()
        {
            _shareData.loadAnimalByName = _model.AnimalName;
            SceneManager.LoadScene(1);
        }
    }
}
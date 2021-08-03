using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

namespace GameScene.AnimalTail
{
    public class AnimalTailController : MonoBehaviour
    {
        [SerializeField] private AnimalTailView animalTailView;
        private AnimalTailModel _model;

        private void Awake()
        {
            _model = new AnimalTailModel();
        }

        public void InitAnimal(AnimalNames name, Sprite img, AnimalSpineController animalSpineController, bool isCorrect = false)
        {
            _model.SetParamsAnimal(name, img, animalSpineController, isCorrect);
            animalTailView.Init(_model);
        }

        public void HighliteTail()
        {
            animalTailView.HighliteTail();
        }

        public void DisableHighliteTail()
        {
            animalTailView.HighliteTailOff();
        }

        public void SetAction(Action act)
        {
            _model.onClickTail = act;
        }
    }
}

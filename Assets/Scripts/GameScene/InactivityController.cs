using System;
using System.Collections;
using System.Collections.Generic;
using GameScene.AnimalTail;
using UnityEngine;

namespace GameScene
{
    public class InactivityController : MonoBehaviour
    {
        [SerializeField] private int _singleTailAnim;
        [SerializeField] private int _allTailAnim = 0;
        [SerializeField] private List<AnimalTailController> _animalTails;

        private int _idleAnimation = 0;

        private void Start()
        {
            StartCoroutine(Timer());
        }

        private void OnDestroy()
        {
            StopCoroutine(Timer());
        }

        private void ResetTimer()
        {
            _idleAnimation = 0;
        }

        IEnumerator Timer()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                _idleAnimation++;
                if (_idleAnimation == _singleTailAnim)
                {
                    _animalTails.ForEach(tail => tail.HighliteTail());
                }

                if (_idleAnimation == _allTailAnim)
                {
                    _animalTails.ForEach(tail => tail.DisableHighliteTail());
                }
            }
        }

        public void AddTailToList(AnimalTailController tail)
        {
            _animalTails.Add(tail);
            tail.SetAction(ResetTimer);
        }
    }
}
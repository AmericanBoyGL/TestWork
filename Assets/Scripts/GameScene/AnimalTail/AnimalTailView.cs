using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObj;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameScene.AnimalTail
{
    public class AnimalTailView : MonoBehaviour
    {
        [SerializeField] private Image _animalTailImg;
        [SerializeField] private Button _tailBtn;
        [SerializeField] private Animator anim;
        
        private AnimalTailModel _model;

        private void Awake()
        {
            _tailBtn.onClick.AddListener(ChackTailCorrect);
        }

        private void Start()
        {
            anim = gameObject.GetComponent<Animator>();
        }

        private void OnDisable()
        {
            StopCoroutine(EndGame());
        }

        public void Init(AnimalTailModel model)
        {
            _model = model;
            _animalTailImg.sprite = _model.ImageAnimalIcon;
        }

        private void ChackTailCorrect()
        {
            _model.onClickTail?.Invoke();
            
            _model.AnimalSpineController.ActivateSlotChanger(_model.ImageAnimalIcon);
            if (_model.IsCorrectTail)
            {
                var countCorrect = AudioManager.GetVoicesCorrect().Count;
                var takeRandVoiceIndex = Random.Range(0, countCorrect);
                AudioManager.PlaySound(AudioManager.GetVoicesCorrect()[takeRandVoiceIndex]);
                _model.AnimalSpineController.PlayAnimation(true);
                StartCoroutine(EndGame());
            }
            else
            {
                var countInCorr = AudioManager.GetVoicesInCorrect().Count;
                var takeRandVoiceIndex = Random.Range(0, countInCorr);
                AudioManager.PlaySound(AudioManager.GetVoicesInCorrect()[takeRandVoiceIndex]);
                _model.AnimalSpineController.PlayAnimation(false);
            }
        }

        IEnumerator EndGame()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(0);
        }

        public void HighliteTail()
        {
            anim.Play("HighliteTail");
            anim.SetBool("isHighlite", false);
        }

        public void HighliteTailOff()
        {
            anim.SetBool("isHighlite", true);
        }
    }
}

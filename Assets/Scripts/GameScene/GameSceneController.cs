using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameScene
{
    public class GameSceneController : MonoBehaviour
    {
        [SerializeField] private Button _exitBtn;

        private void Awake()
        {
            _exitBtn.onClick.AddListener(OnExitButtonClick);
            
        }

        private void OnExitButtonClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}
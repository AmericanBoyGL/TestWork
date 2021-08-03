using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MenuScene
{
    public class MenuSceneController : MonoBehaviour
    {
        [SerializeField] private RectTransform _canvasWidth;
        [SerializeField] private GridLayoutGroup _gridForIcons;
        
        [SerializeField] private PreloadGenerationIcons preloadGenerationIcons;
        private void Start()
        {
            var counnIcons = preloadGenerationIcons.GetCountIcons();
            var sizeForCell = _canvasWidth.rect.width / counnIcons;
            _gridForIcons.cellSize = new Vector2(sizeForCell, sizeForCell);
        }
    }
}

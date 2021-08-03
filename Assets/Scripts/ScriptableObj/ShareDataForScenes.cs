using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "ShareData", menuName = "ScriptableObj/ShareDataForScenes")]
    public class ShareDataForScenes : ScriptableObject
    {
        public AnimalNames loadAnimalByName;
    }
}


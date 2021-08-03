using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "Voice", menuName = "ScriptableObj/VoiceController")]
    public class VoiceController : ScriptableObject
    {
        public int inCorrectAnswerRow;
        public List<AudioClip> correctVoice;
        public List<AudioClip> inCorrectVoice;
    }
}
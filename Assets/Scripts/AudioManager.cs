using System.Collections;
using System.Collections.Generic;
using ScriptableObj;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private VoiceController _voiceData;

    private static AudioManager instance;
 
    private AudioSource player;
 
    private void Awake()
    {
        player = GetComponent<AudioSource>();
    }
 
    void Start()
    {
        if (instance == null) 
            instance = this;
 
        DontDestroyOnLoad(gameObject);
    }
    
    public static List<AudioClip> GetVoicesInCorrect()
    {
        return instance._voiceData.inCorrectVoice;
    }
    
    public static void PlaySound(AudioClip clip) 
    {
        instance.SoundPlay(clip);
    }
    
    public static List<AudioClip> GetVoicesCorrect()
    {
        return instance._voiceData.correctVoice;
    }
    
    private void SoundPlay(AudioClip clip)
    {
        player.clip = clip;
        player.Play();
    }
}

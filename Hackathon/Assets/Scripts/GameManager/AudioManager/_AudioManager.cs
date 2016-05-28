using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum _AudioType
{
    BUTTON = 2,
    GOOD  =3,
    FAIL = 4,
    CLOCK = 5
}

[System.Serializable]
public class AudioProfile
{
    public _AudioType type;
    public AudioClip audio;
}

public class _AudioManager : MonoSingleton<_AudioManager> {

    public List<AudioProfile> listAudio;
    public Dictionary<_AudioType, AudioClip> dicAudio;
    public AudioSource audioSource;
    public AudioSource audioSourceBG;
    // Use this for initialization
    void Awake()
    {
        InitDictionary();
        if (audioSourceBG.clip)
        {
            audioSourceBG.Stop();
        }
    }
    //void start()
    //{
       
    //}
    public void InitDictionary()
    {
        dicAudio = new Dictionary<_AudioType, AudioClip>();
        foreach (AudioProfile var in listAudio)
        {
            dicAudio.Add(var.type, var.audio);
        }
    }

    public void PlayAudio_BG()
    {
        if(audioSourceBG.clip)
        {
            audioSourceBG.Play();
        }
    }
    public void StopAudio_BG()
    {
        if (audioSourceBG.clip)
        {
            audioSourceBG.Stop();
        }
        
    }
    public void SetValueVolume_BG(float value)
    {
        audioSourceBG.volume = value;
    }
    public AudioClip GetAudio(_AudioType type)
    {
        if (dicAudio.ContainsKey(type))
        {
            return dicAudio[type];
        }
#if UNITY_EDITOR
        Debug.Log("ko co type audio nay!");
#endif
        return null;
    }
    public void PlayAudioByType(_AudioType _type, bool _loop)
    {
        AudioClip audio = GetAudio(_type);
        if (audio)
        {
            audioSource.loop = _loop;
            audioSource.clip = audio;
            audioSource.Play();
        }
    }
    public void PlayOneShot(_AudioType _type)
    {
        AudioClip audio = GetAudio(_type);
        if (audio)
        {
            audioSource.PlayOneShot(audio);
        }
    }

    public void StopAudiobyType(_AudioType _type)
    {
        AudioClip audio = GetAudio(_type);
        if (audio)
        {
            audioSource.clip = audio;
            audioSource.Stop();
        }
    }

    public void SetMuteAudio()
    {
        if (audioSource)
        {
            audioSource.mute = true;
        }
    }

    public void SetNoMuteAudio()
    {
        if (audioSource)
        {
            audioSource.mute = false;
        }
    }

    public void SetValueVolume(float value)
    {
        audioSource.volume = value;
    }
}

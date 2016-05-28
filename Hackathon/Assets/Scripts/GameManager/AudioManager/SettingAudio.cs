using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingAudio : MonoBehaviour {
    //public Slider sliderAudio;
    public void OnValueChange_Audio(Slider slider)
    {
        _AudioManager.Instance.SetValueVolume(slider.value);
    }

    public void OnValueChange_Music(Slider slider)
    {
        _AudioManager.Instance.SetValueVolume_BG(slider.value);
    }
}

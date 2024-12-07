using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSlider : MonoBehaviour{
    [SerializeField] Slider volumeSlider;
    
    void Start(){
        Load();
    }

    public void ChangeVolume(){
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load(){
        volumeSlider.value = PersistentData.Instance.getVolume();
    }

    private void Save(){
        PersistentData.Instance.setVolume(volumeSlider.value);
    }
}

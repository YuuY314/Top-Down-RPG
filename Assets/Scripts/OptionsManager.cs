using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager Instance { get; private set; }

    void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    public GameObject optionsObject;
    public Slider audioSlider;
    public Dropdown resolutionDropdown;
    public List<AudioSource> audioSources;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0;
            optionsObject.SetActive(true);
        }
    }

    public void ApplyOptions()
    {
        Time.timeScale = 1;
        optionsObject.SetActive(false);

        foreach(AudioSource audio in audioSources){
            audio.volume = audioSlider.value;
        }

        ChangeResolution();
    }

    void ChangeResolution()
    {
        if(resolutionDropdown.value == 0){
            Screen.SetResolution(1920, 1080, false);
        } else if(resolutionDropdown.value == 1){
            Screen.SetResolution(1600, 900, false);
        } else if(resolutionDropdown.value == 2){
            Screen.SetResolution(1280, 720, false);
        } else if(resolutionDropdown.value == 3){
            Screen.SetResolution(800, 600, false);
        }
    }
}

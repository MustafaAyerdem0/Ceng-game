using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LimitedSliderValue : MonoBehaviour
{
    public Slider sliderDiff;
    public TMP_Text  diff;

    public AudioSource music;

    public Slider musicSlider;

    private void Start()
    {
        sliderDiff.value=0.5f;
        musicSlider.value=1;

        sliderDiff.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        diff.text="Easy";
        // Sadece 0, 50 ve 100 değerlerini kabul et
        if (value <= 0.33f){
            sliderDiff.value = 0; 
            diff.text="Difficulty (Easy)";
            MenuManager.instance.difficult = 7;
        }
            
        else if (value <= 0.66f)
        {
            sliderDiff.value = 0.5f; 
            diff.text="Difficulty (Normal)";
            MenuManager.instance.difficult = 10;
        }
            
        else
        {
            sliderDiff.value = 1; 
            diff.text="Difficulty (Hard)";
            MenuManager.instance.difficult = 14;
        }
            
    }


    public void OnSliderValueChangedMusic()
    {
       music.volume = musicSlider.value;
            
    }
}

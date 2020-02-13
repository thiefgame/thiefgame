using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundGauge : MonoBehaviour
{
    [SerializeField] Slider slider;
    
    void Start()
    {
        //物音ゲージの初期値
        slider.value = 0.0f;
    }

    
    void FixedUpdate()
    {
        //クリックするたびに物音ゲージが増える
        if (Input.GetMouseButtonDown(0))
        {
            slider.value = slider.value + 0.1f;
        }
    }
}

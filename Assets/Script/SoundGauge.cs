using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundGauge : MonoBehaviour
{
    [SerializeField] Slider slider;

    //BGM
    AudioSource audioSource;

    //Update内で1回だけ処理をする為
    bool One;

    void Start()
    {
        One = true;

        audioSource = GetComponent<AudioSource>();

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

        //条件処理
        if (slider.value >= 0.8f)
        {
            if (One)
            {
                audioSource.Play();

                //Update内で1回処理した後falseにする
                One = false;
            }
        }
    }
}

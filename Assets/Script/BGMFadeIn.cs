using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMFadeIn : MonoBehaviour
{
    AudioSource audioSource;
    public bool IsFade;
    public double FadeInSeconds = 1.0;
    bool IsFadeIn = true;
    double FadeInDeltaTime = 0;



    void Start()
    {
      
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //フェードイン処理
        if (IsFadeIn)
        {
            FadeInDeltaTime += Time.deltaTime;
            if (FadeInDeltaTime >= FadeInSeconds)
            {
                FadeInDeltaTime = FadeInSeconds;
                IsFadeIn = false;
            }
            audioSource.volume = (float)(FadeInDeltaTime / FadeInSeconds);
        }

        //クリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.volume = (float)0;
            
        }
    }
}

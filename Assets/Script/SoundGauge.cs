using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundGauge : MonoBehaviour
{
    [SerializeField] Animator UnityChan;
    [SerializeField] Rigidbody Character;
    [SerializeField] Slider slider;
    float gameOver = 0.0f;

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
    
    void Update()
    {


        //ゲージが８割たまったら音楽再生
        if (slider.value >= 0.8f)
        {
            if (One)
            {
                audioSource.Play();

                //Update内で1回処理した後falseにする
                One = false;
            }
        }
        //GameOverがアクティブになったら音楽停止
        if (GameObject.Find("GameOverObject").transform.Find("GameOver").gameObject.activeSelf || slider.value <= 0.8f)
        {
            audioSource.Stop();
        }
    }

    private void FixedUpdate()
    {
        if (UnityChan.GetCurrentAnimatorStateInfo(0).IsName("Crouch") || UnityChan.GetCurrentAnimatorStateInfo(0).IsName("CrouchWalk") || UnityChan.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            //ゲージが０以上の時ゲージが回復する
            if (slider.value > 0)
            {
                slider.value -= 0.0005f;
            }
        }
    }

    //他クラスからaddSoundGaugeを受け取ってslider.valueに加算させる
    void AddGauge(float addSoundGauge)
    {
        slider.value += addSoundGauge;
        gameOver = slider.value;
    }

    //GameOverMessageクラスに変数gameOverを渡すため
    public float Gauge()
    {
        return gameOver;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootGauge : MonoBehaviour
{
    public GameObject[] Foots;
    int a = 0;
    private float countup = 0.0f;

    //テスト用（クリックでゲージ上昇）
    /*
    void Update()
    {
        //クリックしたらFootsを表示する
        if (Input.GetMouseButtonDown(0))
        {
            Foots[a].SetActive(true);
            a += 1;
        }

        //Gaugeが10個溜まったらUpdate処理を終わらす
        if (a==10)
        {
            enabled = false;
        }
    }
    */
    
    //時間経過でゲージ上昇
    void Update()
    {
        //時間をカウントする
        countup += Time.deltaTime;
        if (countup >= 5f)
        { 
            Foots[a].SetActive(true);
            a += 1;
            countup = countup - 5;
        }
        if (a == 10)
        {
            enabled = false;
        }
    }
    

    //GameOverMessageに値を渡す
    public int Gauge()
    {
        return a;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int value;
    public string tresureName;

    /*
    //実験用（クリックしただけで反応する）
    public void Update()
    {
        //クリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            //オブジェクトScoreを取得してvalueの値を送る
            GameObject scoreTextGo = GameObject.Find("Score");
            scoreTextGo.SendMessage("OnScore", value);
                
            this.gameObject.SetActive(false);
        }
    }
    */

    //プレイヤーが金品に近づいてるときにクリックすると反応
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //クリックされたとき
            if (Input.GetMouseButtonDown(0))
            {
                //オブジェクトScoreを取得してvalueの値を送る
                GameObject scoreTextGo = GameObject.Find("Score");
                scoreTextGo.SendMessage("OnScore", value);
                this.gameObject.SetActive(false);
            }
        }
    }

}

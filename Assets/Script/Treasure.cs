using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    GameObject clickedGameObject;
    public int value;
    public string tresureName;


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
    
    /*
    public void OnTriggerStay(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetMouseButtonDown(1))
            {
                GameObject scoreTextGo = GameObject.Find("Score");
                scoreTextGo.SendMessage(tresureName, value);
                this.gameObject.SetActive(false);
            }
        }
        
    }
    */
}

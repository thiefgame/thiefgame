using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int value;
    public string tresureName;
    //public GameObject ItemMessage;


    //実験用（クリックしただけで反応する）
    public void Update()
    {
        //クリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            //オブジェクトScoreを取得してvalueの値を送る
            GameObject scoreTextGo = GameObject.Find("Score");
            scoreTextGo.SendMessage("OnScore", value);
            GameObject ChangeTextTextGo = GameObject.Find("ChangeText");
            ChangeTextTextGo.SendMessage("OnItemName", tresureName);
            StartCoroutine("ItemDetail");
            this.gameObject.SetActive(false);
        }
    }


    //プレイヤーが金品に近づいてるときにクリックすると反応
    /*void OnTriggerStay(Collider other)
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
    }*/
    private IEnumerator ItemDetail()
    {
        GameObject target1 = GameObject.Find("ItemName");

        Transform target2 = target1.transform.Find("ChangeText");
    
        yield return new WaitForSeconds(2.0f);
        target1.transform.Find("ChangeText").SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIをスクリプトから動かせるように追加する

public class Treasure : MonoBehaviour
{
    public int value;
    public string tresureName;
    [SerializeField] GameObject ItemName;

    //プレイヤーが金品に近づいてるときにクリックすると反応
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                ItemName.SetActive(true);

                //オブジェクトScoreを取得してvalueの値を送る
                GameObject scoreTextGo = GameObject.Find("Score");
                scoreTextGo.SendMessage("OnScore", value);

                //オブジェクトChangeTextを取得してtresureNameの値を送る
                GameObject ChangeTextTextGo = GameObject.Find("ChangeText");
                ChangeTextTextGo.SendMessage("OnItemName", tresureName);

                //オブジェクトScoreを取得してvalueの値を送る
                GameObject PauseMenuValueTextGo = GameObject.Find("PauseMenu");
                PauseMenuValueTextGo.SendMessage("GetItemValue", value);               

                //オブジェクトPauseMenuを取得してtresureNameの値を送る
                GameObject PauseMenuTextGo = GameObject.Find("PauseMenu");
                PauseMenuTextGo.SendMessage("GetItemName", tresureName);            

                //treasureオブジェクトを消す
                this.gameObject.SetActive(false);
            }
        }
    }
}

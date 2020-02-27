using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIをスクリプトから動かせるように追加する

public class Treasure : MonoBehaviour
{
    public int value;//アイテムの値段
    public string tresureName;//アイテムの名前
    [SerializeField] GameObject ItemName;//アイテム名が書かれたイメージ画像
    [SerializeField] GameObject TreasureItemCanvas;//アイテム取得サインのキャンバス



    //プレイヤーが金品に近づいてるときにクリックすると反応
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //アイテム取得サイン表示
            TreasureItemCanvas.SetActive(true);
            //アイテム取得サインは常にプレイヤーの方向を向く
            GameObject.Find("TreasureItemCanvas").transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            transform.Rotate(new Vector3(0f, -180f, 0f));

            //クリックしたとき
            if (Input.GetMouseButtonDown(0))
            {
                //stealアニメーションを再生
                if(other.TryGetComponent<Animator>(out Animator animator)) { animator.SetTrigger("Steal"); }

                //アイテム名が書かれた画像を表示
                ItemName.SetActive(true);

                //オブジェクトScoreを取得してvalueの値を送る
                GameObject scoreTextGo = GameObject.Find("Score");
                scoreTextGo.SendMessage("OnScore", value);

                //オブジェクトScoreを取得してtresureNameの値を送る
                GameObject scoreScriptTextGo = GameObject.Find("Score");
                scoreScriptTextGo.SendMessage("OnItemName", tresureName);

                //オブジェクトChangeTextを取得してtresureNameの値を送る
                GameObject ChangeTextTextGo = GameObject.Find("ChangeText");
                ChangeTextTextGo.SendMessage("OnItemName", tresureName);

                //オブジェクトPauseMenuを取得してvalueの値を送る
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

    //プレイヤーがアイテムから離れたら
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //アイテム取得サインを非表示
            TreasureItemCanvas.SetActive(false);
        }
            
    }
}

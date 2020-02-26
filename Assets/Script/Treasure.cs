using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIをスクリプトから動かせるように追加する

public class Treasure : MonoBehaviour
{
    public int value;
    public string tresureName;
    [SerializeField] GameObject ItemName;

    private void Update()
    {
        //GameObject.Find("TreasureItemCanvas").transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform);
    }



    //プレイヤーが金品に近づいてるときにクリックすると反応
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            //GameObject.Find("TreasureItemCanvas").transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            if (Input.GetMouseButtonDown(0))
            {
                if(other.TryGetComponent<Animator>(out Animator animator)) { animator.SetTrigger("Steal"); }

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
}

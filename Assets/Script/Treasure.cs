using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIをスクリプトから動かせるように追加する

public class Treasure : MonoBehaviour
{
    public int value;
    public string tresureName;
    public GameObject ItemMessage;
    AudioSource AitemGetSound;


    public void Start()
    {
        AitemGetSound = GetComponent<AudioSource>();

        GameObject target1 = GameObject.Find("ItemName");

        Transform target2 = target1.transform.Find("ChangeText");

        GameObject.Find("ItemName").transform.Find("ChangeText").gameObject.SetActive(false);
    }

    //実験用（クリックしただけで反応する）
    public void Update()
    {
        //クリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("ItemName").transform.Find("ChangeText").gameObject.SetActive(true);

            //オブジェクトScoreを取得してvalueの値を送る
            GameObject scoreTextGo = GameObject.Find("Score");
            scoreTextGo.SendMessage("OnScore", value);

            //オブジェクトChangeTextを取得してtresureNameの値を送る
            GameObject ChangeTextTextGo = GameObject.Find("ChangeText");
            ChangeTextTextGo.SendMessage("OnItemName", tresureName);
            StartCoroutine("ItemDetail");

            //サウンド再生
            AitemGetSound.Play();

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

        GameObject.Find("ItemName").transform.Find("ChangeText").gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);


        GameObject.Find("ItemName").transform.Find("ChangeText").gameObject.SetActive(false);


    }

}

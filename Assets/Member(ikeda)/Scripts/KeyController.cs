﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    bool isNear;
    Animator animator;
    private GameObject silverKeyIcon;
    [SerializeField] GameObject PopUpPanel;//PopUpMessageのパネル
    [SerializeField] GameObject silver_key;
    string PopUpText;

    void Start()
    {
        isNear = false;
        silverKeyIcon = GameObject.Find("SilverKeyIcon");
        silverKeyIcon.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
        //カギを入手するときの動作
    {
        if (isNear && Input.GetMouseButtonDown(0))
        {

            //PopUpPanekをアクティブに
            PopUpPanel.SetActive(true);

            //このアイテムをとったときに表示するテキスト
            PopUpText = "宝物庫のカギを手に入れた!!";

            //オブジェクトScoreを取得してvalueの値を送る
            GameObject PopUpMessageGo = GameObject.Find("ChangePopUpText");
            PopUpMessageGo.SendMessage("OnPopUpMessage", PopUpText);

            Destroy(silver_key);
            Debug.Log("destroy完了");
            /*if (this.gameObject.name == "gold_key_searchArea")
            {
                goldKeyIcon.SetActive(true);            
                
            }*/


            if(this.gameObject.name == "silver_key_searchArea")
            {
                silverKeyIcon.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isNear = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            other.GetComponent<Animator>().SetTrigger("Steal");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
}

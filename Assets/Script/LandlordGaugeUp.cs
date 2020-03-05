using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandlordGaugeUp : MonoBehaviour
{
 
    private float addSoundGauge = 0.1f;//渡すサウンド値
    private bool isNear;
    private float timeleft;
    string PopUpText;
    [SerializeField] GameObject PopUpPanel;//PopUpMessageのパネル

    private void Start()
    {
        isNear = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isNear = true;
            //アイテム名が書かれた画像を表示
            PopUpPanel.SetActive(true);

            //このアイテムをとったときに表示するテキスト
            PopUpText = "家主が起きちゃう!!";

            //オブジェクトScoreを取得してvalueの値を送る
            GameObject PopUpMessageGo = GameObject.Find("ChangePopUpText");
            PopUpMessageGo.SendMessage("OnPopUpMessage", PopUpText);
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //アイテム取得サインを非表示
            isNear = false;
        }

    }

    

    void Update()
    {
        
            //だいたい1秒ごとに処理を行う
            timeleft -= Time.deltaTime;
            if (timeleft <= 0.0)
            {
                timeleft = 1.0f;
            if (isNear == true)
            {


                GameObject soundGaugeGo = GameObject.Find("SoundGauge");
                soundGaugeGo.SendMessage("AddGauge", addSoundGauge);
            }
        }
    }

    private IEnumerator GaugeUp()
    {
        yield return new WaitForSeconds(1.0f);

        //SoundGaugeオブジェクトのAddGaugeメソッドにサウンド値が渡される
        GameObject soundGaugeGo = GameObject.Find("SoundGauge");
        soundGaugeGo.SendMessage("AddGauge", addSoundGauge);


    }
}

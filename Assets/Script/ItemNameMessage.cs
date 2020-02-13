using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIをスクリプトから動かせるように追加する

public class ItemNameMessage : MonoBehaviour
{
    string a;
    
    //メッセージを受け取る
    void OnItemName(string b)
    {
        a = b;

        //Textコンポーネントを取得する
        Text ChangeText = gameObject.GetComponent<Text>();

        //scoreをテキストとして表示する
        ChangeText.text = a;
        
       
    }

    
}
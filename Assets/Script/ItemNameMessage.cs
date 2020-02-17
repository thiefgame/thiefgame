using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIをスクリプトから動かせるように追加する

public class ItemNameMessage : MonoBehaviour
{
    [SerializeField] GameObject ItemName;
    AudioSource AitemGetSound;
    public AudioClip sound1;
    public AudioClip sound2;
    string a;
    
    //メッセージを受け取る
    void OnItemName(string b)
    {
        a = b;

        //Textコンポーネントを取得する
        Text ChangeText = gameObject.GetComponent<Text>();

        //scoreをテキストとして表示する
        ChangeText.text = a;

        //メッセージを消す
        StartCoroutine("ItemDetail");

        //サウンド再生
        StartCoroutine("ItemGet");
    }

    //２秒後にItemNameを非アクティブ化するメソッド
    private IEnumerator ItemDetail()
    {
        yield return new WaitForSeconds(2.0f);

        ItemName.SetActive(false);
    }

    //アイテムゲット効果音が鳴るメソッド
    private IEnumerator ItemGet()
    {
        AitemGetSound.PlayOneShot(sound1);

        yield return new WaitForSeconds(1.0f);

        AitemGetSound.PlayOneShot(sound2);
    }


}
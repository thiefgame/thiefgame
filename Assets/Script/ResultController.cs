using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultController : MonoBehaviour
{
    [SerializeField] GameObject Node;
    [SerializeField] GameObject Content;
    [SerializeField] GameObject Ctext;
    GameObject Obj;
    GameObject textObj;
    
    //ScoreScriptから取得アイテムの名前と金額が格納された配列を受け取る
    List<string> itemList = ScoreScript.getitemList();
    List<int> scoreList = ScoreScript.getscoreList();


    private void Start()
    {
        StartCoroutine("AddNode");
    }

    private IEnumerator AddNode()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            yield return new WaitForSeconds(0.5f);

            //Textコンポーネントを取得する
            Text ChangeText = Ctext.GetComponent<Text>();

            //scoreをテキストとして表示する
            ChangeText.text = itemList[i] + " " + scoreList[i] + "円";

            //Contentの子としてNodeを生成する
            Obj = (GameObject)Instantiate(Node, this.transform.position, Quaternion.identity);
            Obj.transform.parent = Content.transform;

            //Nodeの子としてtextを生成する
            textObj = (GameObject)Instantiate(Ctext, this.transform.position, Quaternion.identity);
            textObj.transform.parent = Obj.transform;
        }        
    }
}



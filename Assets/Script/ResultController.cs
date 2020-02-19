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

    List<string> resultList = new List<string>();


    void Start()
    {
        DontDestroyOnLoad(this);

        for (int i = 0; i < resultList.Count; i++)
        {
            //Textコンポーネントを取得する
            Text ChangeText = Ctext.GetComponent<Text>();

            //scoreをテキストとして表示する
            ChangeText.text = resultList[i];

            //Contentの子としてNodeを生成する
            Obj = (GameObject)Instantiate(Node, this.transform.position, Quaternion.identity);
            Obj.transform.parent = Content.transform;

            //Nodeの子としてtextを生成する
            textObj = (GameObject)Instantiate(Ctext, this.transform.position, Quaternion.identity);
            textObj.transform.parent = Obj.transform;
        }
    }


    void GetItemName(string ItemName)
    {
        resultList.Add(ItemName);
    }




}

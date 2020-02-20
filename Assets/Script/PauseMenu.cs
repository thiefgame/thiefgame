using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject Node;
    [SerializeField] GameObject Content;
    [SerializeField] GameObject Ctext;
    GameObject Obj;
    GameObject textObj;
    [SerializeField] GameObject ScrollView;

    string ItemName;
    int ItemValue =100;

    void GetItemValue(int a)
    {
        ItemValue = a;
    }

    void GetItemName(string b)
    {
        ItemName = b;

        //Textコンポーネントを取得する
        Text ChangeText = Ctext.GetComponent<Text>();

        //scoreをテキストとして表示する
        ChangeText.text = ItemName +"  " + ItemValue +"円";

        //Contentの子としてNodeを生成する
        Obj = (GameObject)Instantiate(Node, this.transform.position, Quaternion.identity);
        Obj.transform.parent = Content.transform;

        //Nodeの子としてtextを生成する
        textObj = (GameObject)Instantiate(Ctext, this.transform.position, Quaternion.identity);
        textObj.transform.parent = Obj.transform;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ScrollView.activeSelf)
            {
                Time.timeScale = 1f;

                ScrollView.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;

                ScrollView.SetActive(true);
            }                    
        }
    }
}

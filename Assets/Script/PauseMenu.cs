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
    [SerializeField] GameObject GetItemList;
    [SerializeField] GameObject ScroolBar1;
    Button button;

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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GetItemList.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;


                Time.timeScale = 1f;

                GetItemList.SetActive(false);
            }
            else
            {
                
                Cursor.lockState = CursorLockMode.None;

                Time.timeScale = 0f;

                GetItemList.SetActive(true);
            }                    
        }
    }
}

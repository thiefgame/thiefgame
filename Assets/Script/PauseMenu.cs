using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject Node;//取得したアイテム名と金額か書かれるオブジェクト
    [SerializeField] GameObject Content;//アイテム取得一覧のベース
    [SerializeField] GameObject Ctext;//Nodeに張り付いているテキスト
    [SerializeField] GameObject GetItemList;
    [SerializeField] GameObject ScroolBar1;
    GameObject Obj;//生成されたNodeが代入されるオブジェクト
    GameObject textObj;//生成されたctextが代入されるオブジェクト
    Button button;
    public Vector3 scale;//インスペクターから変更できるスケール;
    string ItemName;//アイテムの名前の変数
    int ItemValue =0;//アイテムの値段の変数


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
        Obj.transform.localScale = new Vector3(scale.x, scale.x, scale.z);

        //Nodeの子としてtextを生成する
        textObj = (GameObject)Instantiate(Ctext, this.transform.position, Quaternion.identity);
        textObj.transform.parent = Obj.transform;
        textObj.transform.localScale = new Vector3(scale.x, scale.x, scale.z);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //スコアをメモする変数を宣言する
    public static int score = 0;
    string ItemName;
    //取得アイテムと金額を格納する配列を宣言        
    public static List<string> itemList = new List<string>();
    public static List<int> scoreList = new List<int>();

    public static int getScore()
    {
        return score;
    }


    public static List<string> getitemList()
    {
        return itemList;
    }

    public static List<int> getscoreList()
    {
        return scoreList;
    }

    void Start()
    {
        //シーンが終了してもこのオブジェクトは消えなくなる
       DontDestroyOnLoad(this);
    }

    //メッセージを受け取る
    void OnScore(int num)
    {
        //scoreに受け取った値を追加する
        score += num;

        //取得したアイテムの金額を配列に格納
        scoreList.Add(num);

        //Textコンポーネントを取得する
        Text Score = gameObject.GetComponent<Text>();

        //scoreをテキストとして表示する
        Score.text = "Score:"+ score.ToString()+"円";
    }

    //取得したアイテム名を配列に格納
    void OnItemName(string Item)
    {
        ItemName = Item;

        itemList.Add(ItemName);
    }
}

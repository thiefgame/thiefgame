using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //スコアをメモする変数を宣言する
    int score = 0;

    //メッセージを受け取る
    void OnScore(int num)
    {
        //scoreに受け取った値を追加する
        score += num;

        //Textコンポーネントを取得する
        Text Score = gameObject.GetComponent<Text>();

        //scoreをテキストとして表示する
        Score.text = score.ToString();
    }
}

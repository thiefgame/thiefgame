using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    int score = ScoreScript.getScore();
    // Start is called before the first frame update
    void Start()
    {
        //Textコンポーネントを取得する
        Text Score = gameObject.GetComponent<Text>();

        //scoreをテキストとして表示する
        Score.text = "合計" + score.ToString() + "円";
    }

}

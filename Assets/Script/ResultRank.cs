using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultRank : MonoBehaviour
{
    int score = ScoreScript.getScore();
    // Start is called before the first frame update
    void Start()
    {
        //Textコンポーネントを取得する
        Text Rank = gameObject.GetComponent<Text>();

        if(score > 20000)
        {
            Rank.text = "S";
        }
        else if(score > 10000)
        {
            Rank.text = "A";
        }
        else if(score > 500)
        {
            Rank.text = "B";
        }
        else
        {
            Rank.text = "C";
        }
    }

}

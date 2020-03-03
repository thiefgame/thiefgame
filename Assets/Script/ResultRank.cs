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

        StartCoroutine("RankChange");

     
    }
        private IEnumerator RankChange()
        {
            yield return new WaitForSeconds(3.0f);

        //Textコンポーネントを取得する
        Text Rank = gameObject.GetComponent<Text>();

        if (score > 1000000000)
        {
            Rank.text = "Rank:SSS";
        }
        else if (score > 50000000)
        {
            Rank.text = "Rank:SS";
        }
        else if (score > 3000000)
        {
            Rank.text = "Rank:S";
        }
        else if (score > 2000000)
        {
            Rank.text = "Rank:A";
        }
        else if (score > 1500000)
        {
            Rank.text = "Rank:B";
        }
        else if (score > 1000000)
        {
            Rank.text = "Rank:C";
        }
        else if (score > 500000)
        {
            Rank.text = "Rank:D";
        }
        else if (score > 100000)
        {
            Rank.text = "Rank:E";
        }
        else
        {
            Rank.text = "Rank:F";
        }
    }
    

}

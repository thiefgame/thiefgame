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

        if (score > 20000)
        {
            Rank.text = "Rank:S";
        }
        else if (score > 10000)
        {
            Rank.text = "Rank:A";
        }
        else if (score > 500)
        {
            Rank.text = "Rank:B";
        }
        else
        {
            Rank.text = "Rank:C";
        }
    }
    

}

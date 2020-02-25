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
        StartCoroutine("ChangeScore");
    }
    
    private IEnumerator ChangeScore()
    {
        //Textコンポーネントを取得する
        Text Score = gameObject.GetComponent<Text>();
        
        
        for (int i = 0; i < 30; i++)
        {
            int r1 = Random.Range(0, 10000);


            Score.text = "Total:" + r1.ToString() + "円";

        Debug.Log("0.05待つ前");

        yield return new WaitForSeconds(0.05f);

        Debug.Log("0.05待つ");
        }
        
        //scoreをテキストとして表示する
        Score.text = "Total:" + score.ToString() + "円";           
    }
}
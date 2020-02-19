using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalUI : MonoBehaviour
{
    [SerializeField] GameObject GoalButton;
  
    //プレイヤーがゴール地点に入ったとき
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //クリックしたときゴールボタンを表示して時を止める（FixedUpdateメソッドのみ）
            if (Input.GetMouseButtonDown(0))
            {
                GoalButton.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    //コンティニューボタンを押したとき
    public void OnClickContinue()
    {
        //ポーズを解除してボタンを非表示
        GoalButton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnClickEscape()
    {
        SceneManager.LoadScene("Result");
    }
}

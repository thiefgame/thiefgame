using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour
{
    [SerializeField] GameObject GoalButton;
    [SerializeField] GameObject continueButton;

    
    //プレイヤーがゴール地点に入ったとき
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //クリックしたときゴールボタンを表示して時を止める（FixedUpdateメソッドのみ）
            if (Input.GetMouseButtonDown(0))
            {
                GoalButton.SetActive(true);
                //カーソルを表示させる
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
        }
    }

    //コンティニューボタンを押したとき
    public void OnClickContinue()
    {
        //カーソルを非表示にする
        Cursor.lockState = CursorLockMode.Locked;
        //ポーズを解除してボタンを非表示
        GoalButton.SetActive(false);
        Time.timeScale = 1f;

        Cursor.visible = true;
    }

    public void OnClickEscape()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Result");

    }
}

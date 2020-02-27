using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour
{
    [SerializeField] GameObject GoalButton;//ゴールボタンをアタッチ
    [SerializeField] GameObject continueButton;//コンティニューボタンをアタッチ

    
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

    //エスケープボタンを押したとき
    public void OnClickEscape()
    {
        //ポーズ解除
        Time.timeScale = 1f;
        //リザルト画面にシーン遷移
        SceneManager.LoadScene("Result");
    }
}

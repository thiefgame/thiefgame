using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour
{
    [SerializeField] GameObject GoalButton;
    [SerializeField] GameObject continueButton;
    Button button;
   
    void Start()
    {
        button =continueButton.GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }
    
    //プレイヤーがゴール地点に入ったとき
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //クリックしたときゴールボタンを表示して時を止める（FixedUpdateメソッドのみ）
            if (Input.GetKeyDown(KeyCode.G))
            {
                GoalButton.SetActive(true);

                button = continueButton.GetComponent<Button>();
                //ボタンが選択された状態になる
                button.Select();
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

        Cursor.visible = true;
    }

    public void OnClickEscape()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Result");

    }
}

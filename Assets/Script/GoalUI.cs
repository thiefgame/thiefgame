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

            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Cを押した");
                GoalButton.SetActive(false);
                Time.timeScale = 1f;

                Cursor.visible = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Eを押した");
                Time.timeScale = 1f;
                SceneManager.LoadScene("Result");
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

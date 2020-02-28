using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMessage : MonoBehaviour
{
    public FootGauge footGauge;

    void Start()
    {
        // アクティブなオブジェクトを探す
        GameObject target1 = GameObject.Find("GameOverObject");

        // 非アクティブなオブジェクトを探す
        Transform target3 = target1.transform.Find("GameOver");
    }


    void Update()
    {
        //FootGaugeから渡された値が条件と合えばMessageを表示
        if (footGauge.Gauge()>=10)
        {
            GameObject.Find("GameOverObject").transform.Find("GameOver").gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void OnClickTitle()
    {
        //Time.timeScale = 1f;
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("Title");
    }

    public void OnClickRetry()
    {
        //Time.timeScale = 1f;
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("Main");
    }
}

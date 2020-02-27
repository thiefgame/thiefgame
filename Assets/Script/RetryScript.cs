using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1.UIシステムを使うときに必要なライブラリ
using UnityEngine.UI;
// 2.Scene関係の処理を行うときに必要なライブラリ
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    public void OnClickRetry()
    {
        Time.timeScale = 1f;
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("Main");
    }
}

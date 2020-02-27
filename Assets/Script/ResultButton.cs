using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultButton : MonoBehaviour
{
    [SerializeField] GameObject TitleButton;
    Button button;

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        button = TitleButton.GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void OnClickTitle()
    {
        SceneManager.LoadScene("Title");
    }
}

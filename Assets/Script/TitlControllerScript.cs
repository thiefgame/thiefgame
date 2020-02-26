using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitlControllerScript : MonoBehaviour
{
    public AudioSource ButtonSound;

    [SerializeField] GameObject StartButton;
    Button button;

    List<string> itemList = ScoreScript.getitemList();
    List<int> scoreList = ScoreScript.getscoreList();
    

    void Start()
    {
        button = StartButton.GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();

        ButtonSound = this.GetComponent<AudioSource>();
    }

    public void OnStartButtonClcked()
    {
        itemList.Clear();
        scoreList.Clear();
        ButtonSound.Play();

        Application.LoadLevel("Main");
        //SceneManager.LoadScene("kuroda");
    }

}

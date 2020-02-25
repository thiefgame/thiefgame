using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlControllerScript : MonoBehaviour
{
    public AudioSource ButtonSound;

    private void Start()
    {
        ButtonSound = this.GetComponent<AudioSource>();
    }
    public void OnStartButtonClcked()
    {
        ButtonSound.Play();
        Application.LoadLevel("Main");
        //SceneManager.LoadScene("kuroda");
    }
}

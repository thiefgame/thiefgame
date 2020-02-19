using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}

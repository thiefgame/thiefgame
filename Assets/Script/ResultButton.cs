using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour
{
    public void OnClickTitle()
    {
        SceneManager.LoadScene("Title");
    }
}

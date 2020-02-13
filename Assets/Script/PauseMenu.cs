using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    private List<string> treasureList = new List<string>();


    void OnItemName(string Item)
    {
        treasureList.Add(Item);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 0f;
        }

        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 1f;
        }
    }
}

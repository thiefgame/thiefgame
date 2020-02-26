using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollHandle : MonoBehaviour
{
    private void changeScrollBarValue(string scrollBarName, bool isUp)
    {
        GameObject work = GameObject.Find(scrollBarName);
        if (work)
        {
            float aRatio = work.GetComponent<Scrollbar>().value;
            if (isUp)
            {
                aRatio -= 0.05f; // for from top to bottom direction
            }
            else
            {
                aRatio += 0.05f; // for from top to bottom direction
            }
            work.GetComponent<Scrollbar>().value = aRatio;
        }
    }

    void OnGUI()
    {
        float val = Input.GetAxis("Mouse ScrollWheel");
        if (val > 0.0f)
        {
            changeScrollBarValue("Scrollbar1", /* isUp=*/true);
            Debug.Log("up");
        }
        else if (val < 0.0f)
        {
            changeScrollBarValue("Scrollbar1", /* isUp=*/false);
            Debug.Log("down");
        }
        else
        {
            // do nothing
        }
    }
}

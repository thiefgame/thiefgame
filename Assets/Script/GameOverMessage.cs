using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject target1 = GameObject.Find("GameOverObject");
        Transform target3 = target1.transform.Find("GameOver");
        Debug.Log("target3(transform) = " + target3);
        Debug.Log("target3(gameObject) = " + target3.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //クリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("GameOverObject").transform.Find("GameOver").gameObject.SetActive(true);
        }
    }
}

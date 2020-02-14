using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIをスクリプトから動かせるように追加する

public class MessageBoardScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject target1 = GameObject.Find("ItemName");

        Transform target2 = target1.transform.Find("Image");

        GameObject.Find("ItemName").transform.Find("Image").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("ItemName").transform.Find("Image").gameObject.SetActive(true);
            StartCoroutine("ItemDetail");
        }
    }
    private IEnumerator ItemDetail()
    {
        GameObject target1 = GameObject.Find("ItemName");

        Transform target2 = target1.transform.Find("Image");

        GameObject.Find("ItemName").transform.Find("Image").gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        GameObject.Find("ItemName").transform.Find("Image").gameObject.SetActive(false);

    }
}

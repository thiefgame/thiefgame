using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizStatue : MonoBehaviour
{
    public GameObject myCanvas;
    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        myCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //myCanvas.transform.LookAt(mainCamera.transform);
        myCanvas.transform.rotation = mainCamera.transform.rotation;
        //myCanvas.transform.rotation *= Quaternion.Euler(-myCanvas.transform.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        myCanvas.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        myCanvas.SetActive(false);
    }
}

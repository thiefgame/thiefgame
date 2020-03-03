using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizStatue : MonoBehaviour
{
    public GameObject myCanvas;
    public GameObject mainCamera;
    bool playerInSite = false;

    public GameObject player;
    public GameObject miniGame;
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

        if (playerInSite && Input.GetMouseButtonDown(0))
        {
            player.SetActive(false);
            mainCamera.SetActive(false);
            miniGame.GetComponent<MiniGameLaser>().SetMainObjects(player, mainCamera);
            miniGame.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            myCanvas.SetActive(true);
            playerInSite = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            myCanvas.SetActive(false);
            playerInSite = false;
        }
    }
}

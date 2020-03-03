using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFall : MonoBehaviour
{
    [SerializeField] AudioClip fallClip;
    [SerializeField] AudioClip screamClip;
    [SerializeField] GameObject UnderPlane;
    private float addSoundGauge = 0.3f;//渡すサウンド値

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(screamClip);
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(fallClip);
            //メソッドが走るたびにSoundGaugeオブジェクトのAddGaugeメソッドにサウンド値が渡される
            GameObject soundGaugeGo = GameObject.Find("SoundGauge");
            soundGaugeGo.SendMessage("AddGauge", addSoundGauge);

            Destroy(UnderPlane);
            StartCoroutine("FloorDestroy");
            
        }
    }

    private IEnumerator FloorDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

 }

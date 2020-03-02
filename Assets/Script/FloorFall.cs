using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFall : MonoBehaviour
{
    public AudioClip fallClip;
    public AudioClip screamClip;
    private float addSoundGauge = 0.5f;//渡すサウンド値

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(screamClip);
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(fallClip);
            //メソッドが走るたびにSoundGaugeオブジェクトのAddGaugeメソッドにサウンド値が渡される
            GameObject soundGaugeGo = GameObject.Find("SoundGauge");
            soundGaugeGo.SendMessage("AddGauge", addSoundGauge);
        }
    }

 }

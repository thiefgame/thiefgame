using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JumpSoundManager : MonoBehaviour

{
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip jumpedClip;
    private float addSoundGauge = 0.1f;//渡すサウンド値

    protected AudioSource source;

    public void PlayJumpSE()
    {
        source.PlayOneShot(jumpClip);

        //ジャンプしたタイミングでadd
        GameObject soundGaugeGo = GameObject.Find("SoundGauge");
        soundGaugeGo.SendMessage("AddGauge", addSoundGauge);
    }

    public void PlayJumpedSE()
    {
        source.PlayOneShot(jumpedClip);
    }
}

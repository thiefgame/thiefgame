using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class FootStepSound : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] bool randomizePitch = true;
    [SerializeField] float pitchRange = 0.1f;
    private float addSoundGauge = 0.1f;//渡すサウンド値

    protected AudioSource source;

    private void Awake()
    {
        //アタッチしたソースの一番目を使用する
        source = GetComponents<AudioSource>()[0];
    }

    public void PlayFootstepSE()
    {
        if (randomizePitch)
            source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);

        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);

        //足音が鳴るたびにSoundGaugeオブジェクトのAddGaugeメソッドにサウンド値が渡される
        GameObject soundGaugeGo = GameObject.Find("SoundGauge");
        soundGaugeGo.SendMessage("AddGauge", addSoundGauge);
    }
}

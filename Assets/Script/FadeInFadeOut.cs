using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //パネルのイメージを操作するのに必要

public class FadeInFadeOut : MonoBehaviour
{
	public float fadeInTime = 1.0f;
	public float inTime = 1.0f;
	public float fadeOutTime = 1.0f;
	public float outTime = 1.0f;
	public enum FADE_STATE
	{
		FADE_IN,
		IN,
		FADE_OUT,
		OUT
	}
	public FADE_STATE fadeState = FADE_STATE.FADE_IN;

	public float currentTime = 0.0f;
	private Color textColor;

	// Use this for initialization
	void Start()
	{
		textColor = this.GetComponent<Text>().color;
	}

	// Update is called once per frame
	void Update()
	{

		switch (fadeState)
		{
			case (FADE_STATE.FADE_IN):
				currentTime += Time.deltaTime;
				if (currentTime > fadeInTime)
				{
					currentTime -= fadeInTime;
					fadeState = FADE_STATE.IN;
					textColor.a = 1.0f;
				}
				else
				{
					textColor.a = currentTime / fadeInTime;
				}
				break;
			case (FADE_STATE.IN):
				currentTime += Time.deltaTime;
				if (currentTime > inTime)
				{
					currentTime -= inTime;
					fadeState = FADE_STATE.FADE_OUT;
					textColor.a = 1.0f - currentTime / fadeOutTime;
				}
				else
				{
					textColor.a = 1.0f;
				}
				break;
			case (FADE_STATE.FADE_OUT):
				currentTime += Time.deltaTime;
				if (currentTime > fadeOutTime)
				{
					currentTime -= fadeOutTime;
					fadeState = FADE_STATE.OUT;
					textColor.a = 0.0f;
				}
				else
				{
					textColor.a = 1.0f - currentTime / fadeOutTime;
				}

				break;
			case (FADE_STATE.OUT):
				currentTime += Time.deltaTime;
				if (currentTime > outTime)
				{
					currentTime -= outTime;
					fadeState = FADE_STATE.FADE_IN;
					textColor.a = currentTime / fadeInTime;
				}
				else
				{
					textColor.a = 0.0f;
				}

				break;
		}
		this.GetComponent<Text>().color = textColor;
	}
}



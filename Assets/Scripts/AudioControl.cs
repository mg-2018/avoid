using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
	float t;
	AudioLowPassFilter audioLP;
	
	// Start is called before the first frame update
	void Start()
	{
		t = 1f;
		audioLP = gameObject.GetComponent<AudioLowPassFilter>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Player.isRunning)
		{
			if(t <= 1f)
				t += Time.deltaTime * 2;
		}
		
		else
		{
			if(t >= 0f)
				t -= Time.deltaTime * 2;
		}
		
		audioLP.cutoffFrequency = Mathf.Lerp(1000f, 22000f, t);
	}
}

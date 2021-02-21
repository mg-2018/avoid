using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGen : MonoBehaviour
{
	float regenCool;
	float[] cooltimes = {0.5f, 0.35f, 0.25f, 0.2f, 0.15f, 0.1f, 0.08f, 0.06f, 0.04f, 0.03f};
	
	public GameObject bullet;
	
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(Generate());
	}

	// Update is called once per frame
	void Update()
	{
		if(Player.level <= 10) regenCool = cooltimes[Player.level - 1];
	}
	
	IEnumerator Generate()
	{
		while(true)
		{
			float x = Random.Range(-4.8f, 4.8f);
			Instantiate(bullet, new Vector3(x, 5.5f, 0f), Quaternion.identity);
			
			yield return new WaitForSeconds(regenCool);
		}
	}
}

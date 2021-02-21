using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Rigidbody2D rb;
	SpriteRenderer sr;
	
	float fallSpeed = 0f;
	
	// Start is called before the first frame update
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		sr = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.name == "Floor" || col.name == "Player")
		{
			Destroy(gameObject);
		}
		
		if(col.name == "Player" && Player.hp > 0)
		{
			Player.hp--;
			Debug.Log("Player HP is now " + Player.hp);
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		rb.velocity = new Vector2(0f, -fallSpeed);
		
		if(Player.level == 1) fallSpeed = 2f;
		else fallSpeed = (float)(Player.level);
		
		if(!Player.isRunning)
		{
			sr.color = new Color(0f, 0f, 0f, 0f);
		}
		
		else
		{
			sr.color = new Color(0f, 0f, 0f, 1f);
		}
		
		if(Input.GetKeyDown(KeyCode.R))
		{
			Destroy(gameObject);
		}
	}
}

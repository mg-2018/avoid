using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Rigidbody2D playerRB;
	SpriteRenderer playerSR;
	float moveSpeed = 0f;
	
	public int HPBase;
	public int startupLevel=1;
	
	public static int level;
	public static int hp;
	public static int maxHP;
	public static bool isRunning;
	
	// Start is called before the first frame update
	void Start()
	{
		level = startupLevel;
		moveSpeed = 4f;
		
		maxHP = HPBase;
		hp = HPBase;
		isRunning = true;
		
		playerRB = gameObject.GetComponent<Rigidbody2D>();
		playerSR = gameObject.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position -= new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime;
		}
		
		if(hp == 0)
		{
			playerSR.color = new Color(1f, 0f, 0f, 0f);
			isRunning = false;
		}
		
		else
		{
			playerSR.color = new Color(1f, 0f, 0f, 1f);
			isRunning = true;
		}
		
		if(Input.GetKeyDown(KeyCode.R))
		{
			hp = HPBase;
			maxHP = HPBase;
			level = startupLevel;
		}
		
		if(Input.GetKey(KeyCode.LeftShift) && isRunning)
		{
			playerSR.color = new Color(0f, 0f, 1f, 1f);
			moveSpeed = 8f;
		}
		
		if(Input.GetKeyUp(KeyCode.LeftShift) && isRunning)
		{
			playerSR.color = new Color(1f, 0f, 0f, 1f);
			moveSpeed = 4f;
		}
	}
}

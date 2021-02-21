using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text levelText;
	public Text scoreText;
	public Text HPText;
	public Text gameOver;
	public int startupLevel;
	
	int[] boundScore = {0, 1000, 2000, 3500, 5000, 7000, 9000, 11500, 14000, 17000};
	float score = 0f;
	
	// Start is called before the first frame update
	void Start()
	{
		levelText.text = "Level 1";
		
		score = (1000f * (float)(startupLevel-1));
		scoreText.text = string.Format("{0:00000}pts", Mathf.FloorToInt(score));
		
		HPText.text = "HP 10 / 10";
		
		gameOver.color = new Color(0.2f, 0.2f, 0.2f, 0f);
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Player.isRunning)
		{
			score += (50f + (float)(Player.level-1)*5f) * Time.deltaTime;
			gameOver.color = new Color(0.2f, 0.2f, 0.2f, 0f);
		}
		
		else
		{
			gameOver.color = new Color(0.2f, 0.2f, 0.2f, 1f);
		}
		
		scoreText.text = string.Format("{0:00000}pts", Mathf.FloorToInt(score));
		
		if(Player.level == 10) levelText.text = string.Format("Level MAX");
		else levelText.text = string.Format("Level {0}", Player.level);
		
		if(score >= boundScore[Player.level-1] && Player.level < 10)
		{
			Player.level++;
		}
		
		HPText.text = string.Format("HP {0} / {1}", Player.hp, Player.maxHP);
		
		if(Input.GetKeyDown(KeyCode.R))
		{
			score = (1000f * (float)(startupLevel-1));
		}
	}
}

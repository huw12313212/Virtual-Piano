﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

	public GameObject Player;

	public int killNumber = 0;

	public int enemyNumber = 1;
	public int Wave = 1;

	public Camera mainCamera;

	public List<GameObject> SpawnPoint;
	public List<GameObject> MonsterCandidate;

	public UILabel WaveLabel;
	public UILabel KillLabel;
	public UILabel EnemyLabel;
	public GameObject UIPanel;

	float nextTimer = 5;

	//public 

	public void killed()
	{
		enemyNumber--;
		killNumber++;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (WaveLabel != null) 
		{

						WaveLabel.text = "" + Wave;
						EnemyLabel.text = "" + enemyNumber;
						KillLabel.text = "" + killNumber;
		}

		if (enemyNumber <= 0) 
		{
			nextTimer-= Time.deltaTime;

			if(nextTimer<0)
			{
				nextTimer = 5;
				UIPanel.SetActive(true);

				Wave++;
				enemyNumber = Wave;

				for(int i = 0; i<enemyNumber;i++)
				{
					int positionIndex =	Random.Range(0,SpawnPoint.Count);
					int monsterIndex = Random.Range(0,MonsterCandidate.Count);

					GameObject monster = GameObject.Instantiate(MonsterCandidate[monsterIndex]) as GameObject;
					Vector3 randomDif = new Vector3(Random.Range(0,1.1f)-0.5f,0,	Random.Range(0,1.1f)-0.5f);

					monster.transform.position = SpawnPoint[positionIndex].transform.position+randomDif;



				}

			}
		}

	
	}
}

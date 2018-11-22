using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
 {
	 [Range(1f, 120f)]
	 [SerializeField] float secondsBetweenSpawns = 2f;
	 [SerializeField] EnemyMovement enemyPrefab; // makes sure you can only drag in enemies with an enemymovement script
	 [SerializeField] Transform enemyParentTransform;
	 int enemiesSpawned = 0;
	 [SerializeField] Text scoreText;



	// Use this for initialization
	void Start()
	{
		scoreText.text = enemiesSpawned.ToString();	
	 	StartCoroutine(RepeatedlySpawnEnemies());			
	}

	IEnumerator RepeatedlySpawnEnemies()
	{
		while (true) // forever
		{		
			AddScore();
			var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
			newEnemy.transform.parent = enemyParentTransform;			
			print("Am I waiting?");
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}		
	}	

	private void AddScore()
	{
		enemiesSpawned++;
		scoreText.text = enemiesSpawned.ToString();
	}
}

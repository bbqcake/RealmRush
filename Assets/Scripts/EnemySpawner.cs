using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
 {
	 [Range(0.1f, 100f)][SerializeField] float secondsBetweenSpawns = 8f;
	 [SerializeField] EnemyMovement enemyPrefab; // makes sure you can only drag in enemies with an enemymovement script

	// Use this for initialization
	void Start ()
	{
	 StartCoroutine(spawnEnemies());		
	}

	IEnumerator spawnEnemies()
	{
		while (true) // forever
		{
			Instantiate(enemyPrefab, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}		
	}	
}

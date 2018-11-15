using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
[SerializeField] int hitPoints = 100;
[SerializeField] Collider collisionMesh;

	// Use this for initialization
	void Start () 
	{
		
	}

	private void OnParticleCollision(GameObject other)
	{		
		processHit();
		if (hitPoints <= 0)
		{
			KillEnemy();
		}
	}

	void processHit()
	{
		hitPoints = hitPoints - 10;
		print("Current hitpoints:" + hitPoints);
	}

	private void KillEnemy()
	{
		Destroy(gameObject);
	}
}

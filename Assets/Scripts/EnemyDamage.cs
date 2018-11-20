using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
[SerializeField] int hitPoints = 100;
[SerializeField] Collider collisionMesh;
[SerializeField] ParticleSystem particleHitPrefab;
[SerializeField] ParticleSystem particleDeathPrefab;

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
		particleHitPrefab.Play();
		//print("Current hitpoints:" + hitPoints);
	}

	private void KillEnemy()
	{			
		var vfx = Instantiate(particleDeathPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
		vfx.Play();
	}

}

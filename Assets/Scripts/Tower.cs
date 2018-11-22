﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour {
[SerializeField] Transform objectToPan;
[SerializeField] float attackRange = 10f;
[SerializeField] ParticleSystem projectileParticle;

public Waypoint baseWaypoint; // what the tower is standing on

// state of each tower
Transform targetEnemy;	

	
	// Update is called once per frame
	void Update ()
	{
		SetTargetEnemy();
		if (targetEnemy)
		{
			LookAtEnemy();
			FireAtEnemy();
		}
		else
		{
			Shoot(false);
		}
					
		
	}

	private void SetTargetEnemy()
	{
		var sceneEnemies = FindObjectsOfType<EnemyDamage>();

		if (sceneEnemies.Length == 0)
		{
			return;
		}
		else
		{
			Transform closestEnemy = sceneEnemies[0].transform; // need transform

			foreach (EnemyDamage testEnemy in sceneEnemies)
			{
				closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
			}
			targetEnemy = closestEnemy;
		}		
	}

	private Transform GetClosest(Transform transformA, Transform transformB)
	{
		var distToA = Vector3.Distance(transform.position, transformA.position);
		var distToB = Vector3.Distance(transform.position, transformA.position);
		
		if (distToA < distToB)
		{
			 return transformA;
		}
		return transformB;

	}


	void FireAtEnemy()
	{
		float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
		if (distanceToEnemy >= attackRange)
		{
			Shoot(true);
		}
		else
		{
			Shoot(false);
		}

	}

	private void Shoot(bool isActive)
	{
		var emissionModule = projectileParticle.emission;
		emissionModule.enabled = isActive;
	}

	void LookAtEnemy()
	{
		objectToPan.transform.LookAt(targetEnemy);

		
	}
}

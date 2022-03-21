using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

internal class Enemy : MonoBehaviour
{
	internal EnemyPatrol EnemyPatrol = new EnemyPatrol();
	internal EnemyChase EnemyChase = new EnemyChase();
	internal EnemyDamaged EnemyDamage = new EnemyDamaged();
	internal EnemyAttack EnemyAttack = new EnemyAttack();

	private EnemyStates _currentEnemyState;

	[SerializeField] private NavMeshAgent agent;
	[SerializeField] private bool patrolLoop = true;

	internal NavMeshAgent Agent => agent;

	private Rigidbody[] _rgbodies;
	private void Awake()
	{
		_rgbodies = GetComponentsInChildren<Rigidbody>();
		foreach (var _rgbody in _rgbodies)
		{
			_rgbody.isKinematic = true;
		}
	}

	protected void Start()
	{
		var locations = new List<Vector3>();
		var patrolLocations = GetComponentsInChildren<PatrolLocations>();
		locations.Add(transform.position);
		foreach (var p in patrolLocations)
		{
			p.gameObject.SetActive(false);
			locations.Add(p.transform.position);
		}
			
		EnemyPatrol.Init(patrolLoop, locations);
		EnemyPatrol.Init(this);
		ChangeState(EnemyPatrol);
	}

	private void Update()
	{
		_currentEnemyState?.UpdateState();
	}

	private void ChangeState(EnemyStates newState)
	{
		if (_currentEnemyState == newState) return;
			
		_currentEnemyState?.OutState();
			
		_currentEnemyState = newState;
			
		_currentEnemyState?.BeginState();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PlayerWeapon"))
		{
			// this.gameObject.SetActive(false);
			foreach (var _rgbody in _rgbodies)
			{
				_rgbody.isKinematic = false;
			}
			ChangeState(EnemyDamage);
		}
	}
}

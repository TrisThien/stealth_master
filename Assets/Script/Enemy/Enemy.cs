using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Funzilla
{
	internal class Enemy : MonoBehaviour
	{
		internal const float AttackRange = 3.0f;

		internal readonly EnemyPatrol EnemyPatrol = new EnemyPatrol();

		private EnemyStates _currentEnemyState;
		
		[SerializeField] private NavMeshAgent agent;
		[SerializeField] private bool patrolLoop;
		
		internal NavMeshAgent Agent => agent;

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
			if(_currentEnemyState != null) _currentEnemyState.UpdateState();
		}

		private void ChangeState(EnemyStates newState)
		{
			if (_currentEnemyState == newState) return;
			
			if(_currentEnemyState != null) _currentEnemyState.Out();
			
			_currentEnemyState = newState;
			
			if (_currentEnemyState != null) _currentEnemyState.Begin();
		}
	}
}

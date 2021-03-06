using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

internal class EnemyPatrol : EnemyStates
{
	private bool _patrolLoop, _patrolBack;
	private int _locationNo;
	private List<Vector3> _locations;

	private enum PatrolStates
	{
		Walk, Watch
	}
	private PatrolStates _currentPatrolState;

	internal void Init(bool patrolLoop, List<Vector3> locations)
	{
		_patrolLoop = patrolLoop;
		_locations = locations;
	}

	internal override void BeginState()
	{
		_currentPatrolState = PatrolStates.Walk;
		Enemy.Agent.SetDestination(_locations[0]);
		_patrolBack = false;
		_locationNo = 0;
	}
	
	internal override void UpdateState()
	{
		switch (_currentPatrolState)
		{
			case PatrolStates.Walk:
			{
				var distanceToNextLocation = Vector3.Distance(Enemy.transform.position, _locations[_locationNo]);
				if (distanceToNextLocation <= 0.5f)
				{
					ChangeState(PatrolStates.Watch);
				}
			}

				break;
			case PatrolStates.Watch:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	internal override void OutState()
	{

	}
		
	private void ChangeState(PatrolStates newPatrolState)
	{
		if (_currentPatrolState == newPatrolState) return;
		ExitState();
		_currentPatrolState = newPatrolState;
		EnterNextState();
	}
		
	private void ExitState()
	{
		switch (_currentPatrolState)
		{
			case PatrolStates.Walk:
				Walk();
				break;
			case PatrolStates.Watch:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void Walk()
	{
		if (_patrolBack)
		{
			_locationNo--;
			if (_locationNo < 0)
			{
				_patrolBack = false;
				_locationNo = 1;
			}
		}
		else
		{
			_locationNo++;
			if (_locationNo >= _locations.Count)
			{
				if (_patrolLoop)
				{
					_locationNo = 0;
				}
				else
				{
					_locationNo = _locations.Count - 2;
					_patrolBack = true;
				}
			}
		}
	}

	private void EnterNextState()
	{
		switch (_currentPatrolState)
		{
			case PatrolStates.Walk:
				Enemy.EnemyCharacter.AnimatePistolWalk();
				Enemy.Agent.SetDestination(_locations[_locationNo]);
				break;
			case PatrolStates.Watch:
				Enemy.EnemyCharacter.AnimateLooking();
				EnemyTurn();
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void EnemyTurn()
	{
		// TODO: angle / 180f
		Enemy.transform.DOLookAt(_locations[_locationNo], 1f)
			.OnComplete(() =>
			{
				ChangeState(PatrolStates.Walk);
			});
	}
}

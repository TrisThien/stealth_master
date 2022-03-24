using System;
using Funzilla;
using UnityEngine;
using UnityEngine.AI;

// FSM cho Player: https://gitmind.com/app/doc/4637857181

	public class Player : MonoBehaviour
	{
		private const float Speed = 10f;
		[SerializeField] private DynamicJoystick joystick;
		[SerializeField] private NavMeshAgent agent;
		[SerializeField] private Character character;
		
		private const float WalkSpeed = 9.99f;
		private const float AttackRange = 3f;
		private const float AttackTime = 0.7f;
		
		private float _attackTime;
		private float _hp;

		private Enemy[] _enemies;
		private Enemy _targetKill;
		private Exit _exit;

		private enum States
		{
			Idle, Walk, Run, Attack, Win, Die
		}

		private States _state = States.Idle;

		private void Start()
		{
			Application.targetFrameRate = 60;

			_enemies = FindObjectsOfType<Enemy>();
			_exit = FindObjectOfType<Exit>();

			_hp = 50f;
		}

		private void Update()
		{
			var v = joystick.Direction * Speed;
			agent.velocity = new Vector3(v.x, 0, v.y);

			if (_state != States.Die && Vector3.Distance(transform.position, _exit.transform.position) <= 1f)
			{
				ChangeState(States.Win);
				return;
			}

			if (_hp <= 0)
			{
				ChangeState(States.Die);
			}
			
			switch (_state)
			{
				case States.Idle:
					if(TryAttack()) return;
					if (agent.velocity.magnitude > 0) ChangeState(States.Walk);
					break;
				case States.Walk:
					if(TryAttack()) return;
					if(agent.velocity.magnitude > WalkSpeed) ChangeState(States.Run);
					else if(agent.velocity.magnitude <= 0) ChangeState(States.Idle);
					break;
				case States.Run:
					if(TryAttack()) return;
					if(agent.velocity.magnitude <= WalkSpeed) ChangeState(States.Walk);
					break;
				case States.Attack:
					_attackTime -= Time.deltaTime;
					if (_attackTime <= 0)
					{
						ChangeState(States.Walk);
					}
					else
					{
						KillEnemy();
					}
					break;
				case States.Win:
					break;
				case States.Die:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		private bool TryAttack()
		{
			foreach (var e in _enemies)
			{
				if (Vector3.Distance(e.transform.position, transform.position) < AttackRange && e.Attackable)
				{
					_targetKill = e;
					ChangeState(States.Attack);
					return true;
				}
			}
			return false;
		}
		
		private void KillEnemy()
		{
			var playerMove = _targetKill.transform.position - transform.position;
						
			transform.position += playerMove.normalized * Time.deltaTime * 2;
			transform.forward = playerMove;
			//agent.velocity = Vector3.zero;
		}
		
		private void ChangeState(States newState)
		{
			if (newState == _state) return;
			ExitCurrentState();
			_state = newState;
			EnterNewState();
		}

		private void EnterNewState()
		{
			switch (_state)
			{
				case States.Idle:
					character.AnimateIdle();
					break;
				case States.Walk:
					character.AnimateWalk();
					break;
				case States.Run:
					character.AnimateRun();
					break;
				case States.Attack:
					character.AnimateAttack();
					_attackTime = AttackTime;
					break;
				case States.Win:
					break;
				case States.Die:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void ExitCurrentState()
		{
			switch (_state)
			{
				case States.Idle:
					break;
				case States.Walk:
					break;
				case States.Run:
					break;
				case States.Attack:
					break;
				case States.Win:
					break;
				case States.Die:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}

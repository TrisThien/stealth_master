using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public readonly EnemyPatrol EnemyPatrol = new EnemyPatrol();
    public readonly EnemyChase EnemyChase = new EnemyChase();
    public readonly EnemyAttack EnemyAttack = new EnemyAttack();
    public readonly EnemyDamaged EnemyDamaged = new EnemyDamaged();
    
    private IEnemyState _currentEnemyStates;
    private void Start()
    {
        _currentEnemyStates = EnemyPatrol;
    }

    private void Update()
    {
        _currentEnemyStates = _currentEnemyStates.ChangeState(this);
    }
}

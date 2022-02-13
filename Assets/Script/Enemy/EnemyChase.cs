using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    private readonly Player _player = new Player();
    private const float ChaseRange = 3f;
    private const float AttackRange = 1f;

    public EnemyState ChangeState(Enemy enemy)
    {
        if (SeePlayer(enemy)) Chase(enemy);
        else if (IsNearPlayer(enemy)) return enemy.EnemyAttack;
        return enemy.EnemyPatrol;
    }
    
    private void Chase(Enemy state)
    {
        // TODO
    }
    private bool SeePlayer(Enemy enemy)
    {
        return Vector3.Distance(enemy.transform.position, _player.transform.position) <= ChaseRange;
    }
    private bool IsNearPlayer(Enemy enemy)
    {
        return Vector3.Distance(enemy.transform.position, _player.transform.position) <= AttackRange;
    }
}

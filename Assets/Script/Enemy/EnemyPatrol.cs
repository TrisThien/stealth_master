using UnityEngine;

public class EnemyPatrol : EnemyState
{
    private readonly Player _player = new Player();
    private const float EnemyView = 3f;
    public EnemyState ChangeState(Enemy enemy)
    {
        if(!SeePlayer(enemy)) Patrol(enemy);
        return enemy.EnemyChase;
    }

    private void Patrol(Enemy enemy)
    {
        // TODO
    }

    private bool SeePlayer(Enemy enemy)
    {
        return Vector3.Distance(enemy.transform.position, _player.transform.position) <= EnemyView;
    }
}

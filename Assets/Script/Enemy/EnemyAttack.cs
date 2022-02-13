using UnityEngine;

public class EnemyAttack : EnemyState
{
    private readonly Player _player = new Player();
    private const float AttackRange = 1f;

    public EnemyState ChangeState(Enemy enemy)
    {
        Attack(enemy);
        if (!IsNearPlayer(enemy)) return enemy.EnemyChase;
        return null;
    }

    private void Attack(Enemy enemy)
    {
        // TODO
    }

    private bool IsNearPlayer(Enemy enemy)
    {
        return Vector3.Distance(enemy.transform.position, _player.transform.position) <= AttackRange;
    }
}

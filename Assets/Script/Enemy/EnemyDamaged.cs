public class EnemyDamaged : EnemyState
{
    public EnemyState ChangeState(Enemy enemy)
    {
        throw new System.NotImplementedException();
        Damaged(enemy);
    }

    private void Damaged(Enemy state)
    {
        // TODO
    }
}

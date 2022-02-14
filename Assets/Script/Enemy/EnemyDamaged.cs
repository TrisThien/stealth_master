public class EnemyDamaged : IEnemyState
{
    public IEnemyState ChangeState(Enemy enemy)
    {
        throw new System.NotImplementedException();
        Damaged(enemy);
    }

    private void Damaged(Enemy state)
    {
        // TODO
    }
}

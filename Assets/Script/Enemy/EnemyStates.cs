using UnityEngine;


internal abstract class EnemyStates
{
	protected Enemy Enemy;

	internal void Init(Enemy enemy)
	{
		Enemy = enemy;
	}

	internal abstract void BeginState();

	internal abstract void UpdateState();

	internal abstract void OutState();
}    



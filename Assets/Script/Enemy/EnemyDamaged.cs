
using UnityEngine;

internal class EnemyDamaged : EnemyStates
{
	internal override void BeginState()
	{
		Enemy.Agent.isStopped = true;
	}

	internal override void OutState()
	{
		throw new System.NotImplementedException();
	}
	internal override void UpdateState()
	{
		
	}
}

using UnityEngine;

namespace Funzilla
{
	internal class EnemyStates: MonoBehaviour
	{
		protected Enemy Enemy;

		internal void Init(Enemy enemy)
		{
			Enemy = enemy;
		}

		internal void Begin()
		{
		}

		internal void UpdateState()
		{
		}

		internal void Out()
		{
		}
	}    
}


using UnityEngine;

namespace Funzilla
{
	public class PatrolLocations : MonoBehaviour
	{
		private Vector3 _location;
		private void Start()
		{
			_location = transform.position;
		}
	}
}

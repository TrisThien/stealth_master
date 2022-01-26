using Funzilla;
using UnityEngine;
using UnityEngine.AI;

// FSM cho Player: https://gitmind.com/app/doc/4637857181

namespace Script
{
    public class Player : MonoBehaviour
    {
        private const float Speed = 10f;
        [SerializeField] private DynamicJoystick joystick;
        [SerializeField] private NavMeshAgent agent;
        private void Start()
        {
            Application.targetFrameRate = 60;
        }
        private void Update()
        {
            var v = joystick.Direction * Speed;
            agent.velocity = new Vector3(v.x, 0, v.y);
        }
    }
}

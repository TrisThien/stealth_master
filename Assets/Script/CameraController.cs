using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Player _player;
    private Vector3 _distanceGap;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _distanceGap = transform.position - _player.transform.position;
    }
    private void Update()
    {
        var camMove = _player.transform.position + _distanceGap;
        
        camMove = new Vector3(Mathf.Clamp(camMove.x, -5f, 5f), camMove.y, camMove.z);
        transform.position = camMove;
    }
}

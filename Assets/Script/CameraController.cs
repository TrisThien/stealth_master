using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Player _player;
    private Vector3 _offset;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _offset = transform.position - _player.transform.position;
    }
    private void Update()
    {
        var pos = _player.transform.position + _offset;
        
        pos = new Vector3(Mathf.Clamp(pos.x, -5f, 5f), pos.y, pos.z);
        transform.position = pos;
    }
}

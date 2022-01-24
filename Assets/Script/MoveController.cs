using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private const float Speed = 10.0f;

    // private Vector3 mousePos;
    void Update()
    {
        #region MyRegion

        // if (Input.GetMouseButtonDown(0))
        // {
        //     mousePos = Input.mousePosition;
        // }
        // if (Input.GetMouseButton(0))
        // {
        //     var v = Input.mousePosition - mousePos;
        //     if (v.magnitude <= 0) return;
        //     v = v.normalized;
        //     v *= Speed * Time.smoothDeltaTime;
        //     transform.position += new Vector3(v.x, 0, v.y);

        #endregion
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Move(direction);
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction * Speed * Time.smoothDeltaTime;
    }
}

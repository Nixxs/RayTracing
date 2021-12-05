using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    public void UpdateMovement()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        Vector3 movement = direction.normalized * FindObjectOfType<Player>().speed * Time.fixedDeltaTime;
        transform.Translate(movement);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -FindObjectOfType<Player>().turnspeed * Time.fixedDeltaTime, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, FindObjectOfType<Player>().turnspeed * Time.fixedDeltaTime, 0));
        }
    }

    public void UpdatePlayerInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FindObjectOfType<Rays>().CastRay();
        }
    }
}

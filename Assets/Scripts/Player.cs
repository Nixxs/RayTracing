using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerControl))]
public class Player : MonoBehaviour
{
    public int speed;
    public float turnspeed;

    void Start()
    {
        speed = 7;
        turnspeed = 180f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        FindObjectOfType<PlayerControl>().UpdateMovement();
    }
}

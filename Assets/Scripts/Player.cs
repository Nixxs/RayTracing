using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 7;
    public float turnspeed = 1.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<PlayerControl>().UpdateMovement();
    }
}

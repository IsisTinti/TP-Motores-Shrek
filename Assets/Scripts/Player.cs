using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public float forceJump;
    Control _control;
    Movement _movement;
    void Start()
    {
        _movement = new Movement(transform, rb, speed,forceJump);
        _control = new Control(_movement);
    }

    void Update()
    {
        _control.ArtificialUpdate();
    }

    public void SpeedUp(float add)
    {
        _movement.SpeedUp(add);
    }

    public void ForceJumpUp(float add)
    {
        _movement.ForceJumpUp(add);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _movement.ArtificialOnCollisionEnter(collision);
    }

   /* private void OnTriggerEnter(Collider other)
    {
        var powerUp = other.GetComponent<PowerUp>();

        if (powerUp != null)
            powerUp.Get(this);
    }
   */

}

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
    Life _life;
    public int maxlife;
    public int life;
    public int damage;
    public int upgradeLifeQuantity;
    public Animator animator;

    void Start()
    {
        _movement = new Movement(transform, rb, speed,forceJump);
        _control = new Control(_movement);
        _life = new Life(maxlife, life, damage, upgradeLifeQuantity);

    }

    void Update()
    {
        _control.ArtificialUpdate();
        animator.SetFloat("VelX", Input.GetAxis("Horizontal"));
        animator.SetFloat("VelY", Input.GetAxis("Vertical"));
        animator.SetFloat("VelY", Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _life.TakeDamage();
            print("sufriste " + damage + " de daño! ahora tu vida es de " + life);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _life.GetLife();
            print("recibiste 15 de vida ahora tu vida es de " + life);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            print(life);
        }
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

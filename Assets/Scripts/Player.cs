using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField]
    private AttackRadius AttackRadius;
    private Coroutine LookCoroutine;
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
    //  Alternativa por si el constructor life no funciona
    //----------------------------------------------------------

    [SerializeField]
    private int _health = 100;

    private const string ATTACK_TRIGGER = "Attack";
    //--------------------------------------------------

    private void Awake()
    {
        AttackRadius.OnAttack += OnAttack;
    }



    void Start()
    {
        _movement = new Movement(transform, rb, speed, forceJump);
        _control = new Control(_movement);
        _life = new Life(maxlife, upgradeLifeQuantity);

    }

    void Update()
    {
        _control.ArtificialUpdate();
        animator.SetFloat("VelX", Input.GetAxis("Horizontal"));
        animator.SetFloat("VelY", Input.GetAxis("Vertical"));
        animator.SetFloat("VelY", Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _life.TakeDamage(damage);
            Debug.Log("sufriste " + damage + " de daño! ahora tu vida es de " + life);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _life.GetLife();
            Debug.Log("recibiste 15 de vida ahora tu vida es de " + life);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(life);
        }
    }

    private void OnAttack(IDamageable Target)
    {
        animator.SetTrigger(ATTACK_TRIGGER);

        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt(Target.GetTransform()));
    }

    private IEnumerator LookAt(Transform Target)
    {
        Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);
        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            time += Time.deltaTime * 2;
            yield return null;
        }

        transform.rotation = lookRotation;

    }

    public void TakeDamage(int Damage)
    {
       _life.TakeDamage(Damage);
    }

    public Transform GetTransform()
    {
        return transform;
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


    //---------------PRUEBA POWERUP--------------------------
    /* private void OnTriggerEnter(Collider other)
     {
         var powerUp = other.GetComponent<PowerUp>();

         if (powerUp != null)
             powerUp.Get(this);
     }
    */

}

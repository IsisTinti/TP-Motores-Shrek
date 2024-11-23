using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent),typeof(AgentLinkMover))]
public class EnemyMovement : MonoBehaviour
{
   public Transform Player;
   public float UpdateRate = 0.1f;
   private AgentLinkMover LinkMover;
   public Transform Target;
   public float UpdateSpeed = 0.1f;
   private NavMeshAgent Agent;
    [SerializeField]
    private Animator Animator = null;

    private const string IsWalking = "IsWalking";
    private const string Jump = "jump";
    private const string Landed = "Landed";

    private Coroutine FollowCoroutine;


    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        LinkMover.OnLinkStart += HandleLinkStart;
        LinkMover.OnLinkEnd += HandleLinkEnd;
    }

    private void Start()
    {
        StartCoroutine(FollowTarget());

    }
    public void StartChasing()
    {
        if (FollowCoroutine== null)
        {
            StartCoroutine(FollowTarget());
        } 

        else
        {
            Debug.LogWarning("se llamo StartChasing donde ya estaba en ese estado! jaja re bugeado");
        }
    }
    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);

        while (enabled)
        {
            Agent.SetDestination(Target.transform.position);
            yield return Wait;
        }
    }

    private void HandleLinkStart()
    {
        Animator.SetTrigger(Landed);
    }

    private void HandleLinkEnd()
    {
        Animator.SetTrigger(Landed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transform;
    private BoxCollider boxCollider;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    // public Transform[] navPoints;
    private int navIndex;
    private double speed = 0;
    private string RUNNING_ANIMATION = "isMoving";
    public Transform player;
    public float distance;
    void Start()
    {
        transform = GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        navIndex = 0;
        // navMeshAgent.Warp(navPoints[navIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 position = transform.position;

        position.z = player.position.z + distance;
        position.x = player.position.x >= 10 ? player.position.x - 1 : position.x;
        position.y = player.position.y;
        transform.position = position;

        transform.rotation = player.rotation;
    }

    void StartRunningAnimation()
    {
        animator.SetBool(RUNNING_ANIMATION, true);
        speed = 10f;
    }

    void EndRunningAnimation()
    {
        animator.SetBool(RUNNING_ANIMATION, false);
        speed = 0f;
    }

}

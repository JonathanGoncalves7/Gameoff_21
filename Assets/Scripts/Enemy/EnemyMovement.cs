using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Speeds")]
    public float speedBase = 1f;
    public float speedToEachOpenEye = 3f;
    public float maxSpeed = 30f;

    [Header("Patrol")]
    public bool patrol = true;
    public GameObject patrolPoints;
    public float maxTimeToNextPoint = 5f;

    private int currentPointIndex;
    private float timeToNextPoint = 0f;
    private float leftTimeNextPoint = 0f;

    NavMeshAgent agent;
    GameObject player;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        timeToNextPoint = UnityEngine.Random.Range(1f, maxTimeToNextPoint);
    }

    void Update()
    {
        if (patrol)
        {
            Patrol();
        }
        else
        {
            FollowPlayer();
        }
    }

    private float GetSpeed()
    {
        float currentSpeed = speedBase;

        if (EyesManager.Instance.LeftAndRightEyesIsOpen())
        {
            currentSpeed += EyesManager.Instance.LeftEyeIsOpen() ? speedToEachOpenEye : 0;
            currentSpeed += EyesManager.Instance.RightEyeIsOpen() ? speedToEachOpenEye : 0;
        }


        if (!patrol)
        {
            currentSpeed *= Mathf.Max(SanityController.Instance.GetSecondsInFear(), 1);
        }

        return currentSpeed > maxSpeed ? maxSpeed : currentSpeed;
    }

    private void FollowPlayer()
    {
        agent.speed = GetSpeed();

        if (Vector3.Distance(transform.position, player.transform.position) > 0.5f)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.isStopped = true;
            agent.SetDestination(transform.position);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerController.Instance.Death();
            patrol = true;
        }
    }

    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.speed = GetSpeed();

            leftTimeNextPoint += Time.deltaTime;

            if (leftTimeNextPoint >= timeToNextPoint)
            {
                leftTimeNextPoint = 0;
                timeToNextPoint = UnityEngine.Random.Range(0.5f, maxTimeToNextPoint);

                int nextPointsIndex = 0;

                do
                {
                    nextPointsIndex = UnityEngine.Random.Range(0, patrolPoints.transform.childCount);
                } while (currentPointIndex == nextPointsIndex);

                currentPointIndex = nextPointsIndex;
                Transform child = patrolPoints.transform.GetChild(nextPointsIndex);
                agent.SetDestination(child.position);
            }
        }
    }
}

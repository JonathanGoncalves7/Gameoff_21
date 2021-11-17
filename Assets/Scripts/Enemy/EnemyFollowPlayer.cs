using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speedBase = 2f;
    public float speedToEachOpenEye = 5f;

    NavMeshAgent navMesh;
    GameObject player;

    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        FollowPlayer();
    }

    private float GetSpeed()
    {
        float currentSpeed = speedBase;

        if (EyesManager.Instance.LeftAndRightEyesIsOpen())
        {
            currentSpeed += EyesManager.Instance.LeftEyeIsOpen() ? speedToEachOpenEye : 0;
            currentSpeed += EyesManager.Instance.RightEyeIsOpen() ? speedToEachOpenEye : 0;
        }

        return currentSpeed;
    }

    private void FollowPlayer()
    {
        navMesh.speed = GetSpeed();

        if (Vector3.Distance(transform.position, player.transform.position) > 2f)
        {
            navMesh.isStopped = false;
            navMesh.SetDestination(player.transform.position);
        }
        else
        {
            navMesh.isStopped = true;
            navMesh.SetDestination(transform.position);
        }
    }
}

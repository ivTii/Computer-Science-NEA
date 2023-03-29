using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    float roamingRadius = 150f;
    float proximityRadius = 50f;
    float killRadius = 1f;
    public Transform player;
    NavMeshAgent agent;

    public static MoveTo instance;

    public bool isPlayerClose = false;
    public bool playerDeath = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("Roam", 0f, 3f);

        instance = this;
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, proximityRadius, LayerMask.GetMask("Player"));

        if (Physics.CheckSphere(transform.position, proximityRadius, LayerMask.GetMask("Player")))
        {
            isPlayerClose = true;
            agent.destination = player.position;
            agent.speed = 6f;
        }
        else
        {
            isPlayerClose = false;
            agent.speed = 8f;
        }



        if (isPlayerClose)
        {
            if (Physics.CheckSphere(transform.position, killRadius, LayerMask.GetMask("Player")))
            {
                playerDeath = true;
            }
        }



    }

    

    void Roam()
    {
        if (!isPlayerClose)
        {
            Vector3 randomDirection = Random.insideUnitSphere * roamingRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, roamingRadius, 1);
            Vector3 finalPosition = hit.position;
            agent.SetDestination(finalPosition);
        }
    }
}

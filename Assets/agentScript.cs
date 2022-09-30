using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentScript : MonoBehaviour
{
    public Transform DestinationTransform;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        DestinationTransform = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = DestinationTransform.position;
    }
}

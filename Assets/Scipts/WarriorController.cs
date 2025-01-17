using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WarriorController : MonoBehaviour
{
    private NavMeshAgent warrior;

    private void Start()
    {
        warrior = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 destination)
    {
        warrior.SetDestination(destination);
    }
}
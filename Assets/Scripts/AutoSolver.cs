using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AutoSolver : MonoBehaviour
{
    [SerializeField]
    GameObject EndPoint;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(EndPoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

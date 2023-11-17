using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solver : MonoBehaviour
{

    public Chromosome Chromosome;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NextAction()
    {
        Debug.Log("next action");
        if (!Chromosome.AnyGenes()) { return; }
        Vector3 nextPoint = Chromosome.NextGene();
        GetComponent<Mover>().MoveToPoint(nextPoint);
    }

    public float GetFitness(Vector3 targetPoint)
    {
        return (targetPoint - transform.position).magnitude;
    }

}

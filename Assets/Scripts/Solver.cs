using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solver : MonoBehaviour
{

    public Chromosome Chromosome;

    public bool Fit = false;

    public Vector3 TargetPoint { get; set; }

    public float Fitness { get { return GetFitness(); } }

    public float PrevGenFit { get; set; }

    public bool Finished = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NextAction()
    {
        if (!Chromosome.AnyGenes()) { return; }
        int rotate = Chromosome.NextGene();
        GetComponent<Mover>().Rotate(rotate);
    }

    public float GetFitness()
    {
        //better fitness
        //check if line of sight to endpoint, that is really good
        //check if total positive distance travelled from start (dont count backtracked)
        //check total "new" area covered, so track all area covered by
        return (TargetPoint - transform.position).magnitude;
    }
    public static int CompareSolver(Solver leftHand, Solver rightHand)
    {
        
        if (leftHand == null)
        {
            if (rightHand == null)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        else
        {

            if (rightHand == null)
            {
                return 1;
            }
            else
            {
                if (leftHand.GetFitness() < rightHand.GetFitness())
                {
                    return -1;
                }
                if(rightHand.GetFitness() < leftHand.GetFitness())
                {
                    return 1;
                }
                return 0;
            }
        }
    }

    public void Reset(Vector3 start)
    {
        PrevGenFit = GetFitness();
        Chromosome.Reset();
        GetComponent<Mover>().Reset();
        transform.position = start;
        transform.rotation = Quaternion.identity;
        Finished = false;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Reached End");
        Finished = true;
        GetComponent<Mover>().Finished();
    }
}

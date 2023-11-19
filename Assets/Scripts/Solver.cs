using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solver : MonoBehaviour
{

    public Chromosome Chromosome;

    public bool Fit = false;

    public Vector3 TargetPoint;

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
}

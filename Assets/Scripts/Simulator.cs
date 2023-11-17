using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour
{

    [SerializeField]
    float MoveTime = 1f;
    [SerializeField]
    List<Solver> solvers = new List<Solver>();

    [SerializeField]
    int MoveCounter = 0;
    float moveTimer = 0f;

    SimulatorSettings settings;
    // Start is called before the first frame update
    void Start()
    {
        settings = GetComponent<SimulatorSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        if(solvers.Count == 0) { return; }
        if(MoveCounter >= settings.MaxGenes) { 
            //time for a new population
            return; 
        }
        if(moveTimer > MoveTime)
        {
            MoveCounter++;
            moveTimer = 0f;
            foreach(Solver solver in solvers)
            {
                //next gene
                solver.NextAction();
            }
        }
        moveTimer += Time.deltaTime;
    }

    void ResetPop()
    {
        //figure out which solvers are the fitest
        //set all solvers to start point
        //generate new chromosomes
    }
}

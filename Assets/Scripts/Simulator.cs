using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour
{

    [SerializeField]
    float MoveTime = 1f;

    [SerializeField]
    int MoveCounter = 0;
    float moveTimer = 0f;

    SimulatorSettings settings;
    Population pop;
    // Start is called before the first frame update
    void Start()
    {
        settings = GetComponent<SimulatorSettings>();
        pop = GetComponent<Population>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pop.Solvers.Count == 0) { return; }
        if(MoveCounter >= settings.MaxGenes) { 
            ResetPop();
            return; 
        }
        if(moveTimer > MoveTime)
        {
            MoveCounter++;
            moveTimer = 0f;
            foreach(Solver solver in pop.Solvers)
            {
                //next gene
                solver.NextAction();
            }
        }
        moveTimer += Time.deltaTime;
    }

    void ResetPop()
    {
        MoveCounter = 0;
        pop.NewGeneration();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Simulator : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI GenCounter;

    [SerializeField]
    int MoveCounter = 0;
    float moveTimer = 0f;
    float maxMove = 0f;

    int generationCounter = 1;

    SimulatorSettings settings;
    Population pop;
    // Start is called before the first frame update
    void Start()
    {
        settings = GetComponent<SimulatorSettings>();
        pop = GetComponent<Population>();
        GenCounter.text = generationCounter.ToString();
        maxMove = settings.SimulationTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(pop.Solvers.Count == 0) { return; }
        if(MoveCounter >= settings.MaxGenes) { 
            ResetPop();
            return; 
        }
        if(moveTimer > maxMove)
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
        generationCounter++;
        GenCounter.text = generationCounter.ToString();
        MoveCounter = 0;
        pop.NewGeneration(generationCounter);
        foreach(Solver s in pop.Solvers)
        {
            s.Reset(settings.StartPoint.transform.position);
        }
    }

    public void PauseSimulation() 
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return;
        }
        Time.timeScale = 0;
    }

    public void ChangeTime(float value)
    {
        Time.timeScale = value;
    }


}

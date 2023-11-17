using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{

    List<Chromosome> chromosomes = new List<Chromosome>();

    [SerializeField]
    List<Solver> solvers;

    SimulatorSettings settings;
    // Start is called before the first frame update
    void Start()
    {
        settings = GetComponent<SimulatorSettings>();
        NewPopulation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewPopulation()
    {
        for(int i = 0; i < settings.PopulationSize; i++)
        {
            Chromosome newChromo = new Chromosome( (settings.minVector, settings.maxVector), settings.MaxGenes);
            solvers[i].Chromosome = newChromo;
        }

    }

    public void CrossoverPop() { }

}

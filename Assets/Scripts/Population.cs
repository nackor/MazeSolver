using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    [SerializeField]
    public int PopulationSize = 1;
    List<Chromosome> chromosomes = new List<Chromosome>();

    [SerializeField]
    List<Solver> solvers;

    [SerializeField]
    Vector3 minVector;
    [SerializeField]
    Vector3 maxVector;

    // Start is called before the first frame update
    void Start()
    {
        NewPopulation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewPopulation()
    {
        for(int i = 0; i < PopulationSize; i++)
        {
            Chromosome newChromo = new Chromosome( (minVector,maxVector),10);
            solvers[i].Chromosome = newChromo;
        }

    }
}

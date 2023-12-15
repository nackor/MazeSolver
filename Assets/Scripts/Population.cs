using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{

    List<Chromosome> chromosomes = new List<Chromosome>();

    [SerializeField]
    public List<Solver> Solvers;

    [SerializeField]
    GameObject solverPrefab;

    SimulatorSettings settings;
    // Start is called before the first frame update
    void Start()
    {
        Solvers = new List<Solver>();
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
            GameObject newSolver = Instantiate(solverPrefab, settings.StartPoint.transform.position,Quaternion.identity);
            Solvers.Add(newSolver.GetComponent<Solver>());
            newSolver.GetComponent<Solver>().TargetPoint = settings.EndPoint.transform.position;
            Chromosome newChromo = new Chromosome( (settings.minVector, settings.maxVector), settings.MaxGenes);
            Solvers[i].Chromosome = newChromo;
            newChromo.Generation = 1;
        }

    }


    public void NewGeneration(int genNumber)
    {
        List<Solver> fittest = new List<Solver>();
        Solvers.Sort(Solver.CompareSolver);
        Solver parent1 = null;
        Solver parent2 = null;
        bool newParents = true;
        for (int i = 0; i < Solvers.Count; i++)
        {
            if (i > (int)(Solvers.Count * settings.FittestToKeep))
            {
                Chromosome newChromo = new Chromosome((settings.minVector, settings.maxVector), settings.MaxGenes);
                Solvers[i].Chromosome = newChromo;
                newChromo.Generation = genNumber;
                //crossover all children
                //pick random parent1
                //pick random parent2
                if (parent1 == null)
                {
                    //pick random parent1
                    parent1 = Solvers[Random.Range(0, Solvers.Count)];
                    //pick random parent2
                    parent2 = Solvers[Random.Range(0, Solvers.Count)];
                    while (parent2 == parent1)
                    {
                        parent2 = Solvers[Random.Range(0, Solvers.Count)];
                    }

                }
                newChromo.CrossoverGene(parent1.Chromosome, parent2.Chromosome);
                Solvers[i].GetComponent<MeshRenderer>().material.color = Color.white;

            }
            else
            {
                Solvers[i].GetComponent<MeshRenderer>().material.color = Color.green;
            }


            //check for mutation
            for(int j=0; j<settings.MaxGenes; j++)
            {
                if (Random.Range(0, 1f) < settings.MutationChance)
                {
                    Solvers[i].Chromosome.MutateGene(j);
                }
            }
        }

    }

}

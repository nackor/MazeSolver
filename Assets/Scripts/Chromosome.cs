using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chromosome
{

    public List<Vector3> Genes;

    private int geneCounter;

    private Vector3 minGene;
    private Vector3 maxGene;

    public int Generation { get; set; }

    public Chromosome((Vector3,Vector3) minMaxGenes,int geneLength)
    {
        minGene = minMaxGenes.Item1;
        maxGene = minMaxGenes.Item2;
        Genes = new List<Vector3>();
        geneCounter = 0;
        for(int i = 0; i < geneLength; i++)
        {
            
            float x = Random.Range(minMaxGenes.Item1.x, minMaxGenes.Item2.x);
            float y = Random.Range(minMaxGenes.Item1.y, minMaxGenes.Item2.y);
            float z = Random.Range(minMaxGenes.Item1.z, minMaxGenes.Item2.z);
            Genes.Add(new Vector3(x,y,z));
        }
    }
    public Vector3 NextGene()
    {
        geneCounter++;
        return Genes[geneCounter-1];
    }

    public bool AnyGenes()
    {
        if(geneCounter >= Genes.Count)
        {
            return false;
        }
        return true;
    }
    
    public void MutateGene(int gene)
    {
        float x = Random.Range(minGene.x, maxGene.x);
        float y = Random.Range(minGene.y, maxGene.y);
        float z = Random.Range(minGene.z, maxGene.z);
        Genes[gene] = new Vector3(x, y, z);
    }

    public void CrossoverGene(Chromosome parent1, Chromosome parent2)
    {
        //pick random gene to start
        int starting = Random.Range(0,Genes.Count);
        int endSlice = (starting + Genes.Count / 2)%Genes.Count;        
        for (int i = starting; i < starting + Genes.Count / 2; i++)
        {
            Genes[i%Genes.Count] = parent1.Genes[i%Genes.Count];
        }
        for (int i = endSlice; i < endSlice + Genes.Count / 2; i++)
        {
            Genes[i % Genes.Count] = parent2.Genes[i % Genes.Count];
        }
        //take half from parent two
    }

    public void Reset()
    {
        geneCounter = 0;
    }
}

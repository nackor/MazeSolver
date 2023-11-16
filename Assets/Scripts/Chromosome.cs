using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chromosome
{

    private List<Vector3> genes;

    private int geneCounter;

    public Chromosome((Vector3,Vector3) minMaxGenes,int geneLength)
    {
        genes = new List<Vector3>();
        geneCounter = 0;
        for(int i = 0; i < geneLength; i++)
        {
            float x = Random.Range(minMaxGenes.Item1.x, minMaxGenes.Item2.x);
            float y = Random.Range(minMaxGenes.Item1.y, minMaxGenes.Item2.y);
            float z = Random.Range(minMaxGenes.Item1.z, minMaxGenes.Item2.z);
            genes.Add(new Vector3(x,y,z));
        }
    }
    public Vector3 NextGene()
    {
        geneCounter++;
        return genes[geneCounter-1];
    }

    public bool AnyGenes()
    {
        if(geneCounter >= genes.Count)
        {
            return false;
        }
        return true;
    }

}

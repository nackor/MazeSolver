using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatorSettings : MonoBehaviour
{
    [SerializeField]
    public float SimulationTime = 1f;
    [SerializeField]
    public float SolverSpeed = 5f;
    [SerializeField]
    public int MaxGenes = 10;
    [SerializeField]
    public Vector3 StartPoint;
    [SerializeField]
    public GameObject EndPoint;
    [SerializeField]
    public Vector3 minVector;
    [SerializeField]
    public Vector3 maxVector;
    [SerializeField]
    public int PopulationSize = 1;
    [SerializeField]
    public float MutationChance = .005f;
    [SerializeField]
    public float FittestToKeep = .3f;
}

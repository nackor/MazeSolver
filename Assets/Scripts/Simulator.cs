using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour
{

    [SerializeField]
    float MoveTime = 1f;
    [SerializeField]
    List<Solver> solvers = new List<Solver>();

    float moveTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //solvers = FindObjectsByType<Solver>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    void Update()
    {
        if(solvers.Count == 0) { return; }
        if(moveTimer > MoveTime)
        {
            moveTimer = 0f;
            foreach(Solver solver in solvers)
            {
                //next gene
                solver.NextAction();
            }
        }
        moveTimer += Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    public float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToPoint(Vector3 target)
    {
        this.GetComponent<Rigidbody>().velocity = (target-transform.position).normalized*Speed;
    }
}

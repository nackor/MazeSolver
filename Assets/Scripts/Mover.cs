using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float speed = 0f;

    float originSpeed = 0f;

    public Vector3 Target { get; set; }

    float totalDistance = 0f;

    // Start is called before the first frame update
    void Start()
    {
        speed = FindObjectOfType<SimulatorSettings>().SolverSpeed;
        originSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Target = transform.position + transform.forward*speed;
        transform.position += (Target - transform.position).normalized * speed * Time.deltaTime;
        if (transform.position.y > 1.01f)
        {
            transform.position = new Vector3(transform.position.x,1f,transform.position.z);
        }
    }


    public void Rotate(int amount)
    {
        transform.rotation *= Quaternion.AngleAxis(amount, transform.up);
    }

    public void Finished()
    {
        speed = 0f;
    }

    public void Reset()
    {
        speed = originSpeed;
        totalDistance = 0;
    }
}

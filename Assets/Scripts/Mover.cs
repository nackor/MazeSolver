using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float speed = 0f;


    public Vector3 Target { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        speed = FindObjectOfType<SimulatorSettings>().SolverSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Target = transform.position + transform.forward;
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
    //public void MoveToPoint(Vector3 target)
    //{
    //    this.GetComponent<Rigidbody>().velocity = (target-transform.position).normalized * speed;
    //}
}

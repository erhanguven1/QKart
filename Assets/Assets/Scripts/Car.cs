using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float prob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // * * * *
        if (other.GetComponent<Obstacle>()&&prob!=0)
        {
            FindObjectOfType<CarController>().Collapse(FindObjectOfType<CarController>().spheres.IndexOf(this));
        }
    }
}

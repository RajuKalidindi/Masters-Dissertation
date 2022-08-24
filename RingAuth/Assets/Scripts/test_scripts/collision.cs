using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "R4")
        {
            Debug.Log("R4 collision");
        }
        else if (collision.gameObject.name == "R3")
        {
            Debug.Log("R3 collision");
        }
        else if (collision.gameObject.name == "R2")
        {
            Debug.Log("R2 collision");
        }
        else if (collision.gameObject.name == "R1")
        {
            Debug.Log("R1 collision");
        }
    }
}

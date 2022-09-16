using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    float distance = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            transform.Translate(Vector3.up * distance);
        }

        if (Input.GetKeyDown("a"))
        {
            transform.Translate(Vector3.left * distance);
        }

        if (Input.GetKeyDown("s"))
        {
            transform.Translate(Vector3.down * distance);
        }

        if (Input.GetKeyDown("d"))
        {
            transform.Translate(Vector3.right * distance);
        }
    }
}

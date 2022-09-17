using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNOTGate : MonoBehaviour
{
    [SerializeField]
    private BellState bell_s;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        int character = col.GetComponent<MovementController>().characterNum;
        if (character == 0)
            bell_s.CNOTGate(character, character + 1);
        else
            bell_s.CNOTGate(character, character - 1);
    }
}

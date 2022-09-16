using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGate : MonoBehaviour
{
    [SerializeField]
    private BellState bellState;

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

        bellState.RotateState(character);
    }
}

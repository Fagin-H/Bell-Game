using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //Gives each character a number to identify them and which state or qubit they relate to
    [SerializeField]
    private int characterNum;
    //Gives access to the BellState values
    [SerializeField]
    private BellState bellState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Will call the Move function when a key is pressed
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            Move(0);
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            Move(1);
        }

        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            Move(2);
        }

        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            Move(3);
        }
    }

    //Moves the character depending on the state and what key was pressed
    void Move(int keyPressed)
    {
        //Currently only the first element of the state is used to calculate movement. This will change if un-entangled movement is added
        int state = bellState.state[characterNum, 0];

        //Makes an array of vectors for each direction the character can move
        Vector3[] movements = new Vector3[4] { Vector3.up, Vector3.right, Vector3.down, Vector3.left };

        //Inverts or rotates the order of the vectors depending on what the current BellState is
        if (state == 1)
        {
            (movements[0], movements[1], movements[2], movements[3]) = (movements[2], movements[3], movements[0], movements[1]);
        }
        if (state == 2)
        {
            (movements[0], movements[1], movements[2], movements[3]) = (movements[1], movements[2], movements[3], movements[0]);
        }
        if (state == 3)
        {
            (movements[0], movements[1], movements[2], movements[3]) = (movements[3], movements[0], movements[1], movements[2]);
        }

        //Moves the character in the correct direction
        transform.Translate(movements[keyPressed]);
    }
}

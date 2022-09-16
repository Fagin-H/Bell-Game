using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BellState : MonoBehaviour
{
    // state holds the states for each character or qubit. 0 is no change, 1 is inverted, 2 is rotated clockwise, 3 is rotates anticlockwise. Corrsponding to the 0,1,+, and - states.
    // state[i, 0] is the first element of the ith state, state[0, i] is the ith element of the first state. Currently the 2 element does nothing, but can be used later if we include non entangled states.
    public int[,] state = new int[2, 2] { { 0, 1 }, { 0, 1 } };

    //To try out diffrent states uncomment out one of these and comment out the state above.
    //public int[,] state = new int[2, 2] { {1, 0 }, {0, 1} }; //The state where the first character movement is inverted.
    //public int[,] state = new int[2, 2] { {2, 3 }, {0, 1} }; //The state where the first character movement is rotated clockwise.
    //public int[,] state = new int[2, 2] { {1, 0 }, {2, 3} }; //The state where the first character movement is inverted and the second character movement is rotated anti-clockwise.
    
    // chars hold the characters to print in text for each state.
    char[] chars = new char[] { "0"[0], "1"[0], "+"[0], "-"[0] };

    //This is so that the script can edit the text shown to the player.
    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    void Update()
    {
        //This makes the text reflect the current state, if the state is changed this will automaticly display the correct text.
        textMeshPro.text = "Bell State: |" + chars[state[0, 0]] + chars[state[1, 0]] + ">+|" + chars[state[0, 1]] + chars[state[1, 1]] + ">";
    }
    
    //Inverts the current state, turns 0 into 1, 1 into 0, + into - and - into +. This is not how an actual X gate works as it would not change the + into - or - into +. But as we actually have 3 quibits just 1 is hidden
    //this is ok. And to non quantum people this will make more sense to them. We can update in the future to make it more accurate if we wish.
    public void InvertState(int characterNum)
    {
        if (state[characterNum, 0] == 0 || state[characterNum, 0] == 2)
        {
            state[characterNum, 0] = state[characterNum, 0] + 1;
        }
        else
        {
            state[characterNum, 0] = state[characterNum, 0] - 1;
        }
        if (state[characterNum, 1] == 0 || state[characterNum, 1] == 2)
        {
            state[characterNum, 1] = state[characterNum, 1] + 1;
        }
        else
        {
            state[characterNum, 1] = state[characterNum, 1] - 1;
        }
    }

    //Rotates the state, turns 0 into +, + into 0, 1 into -, and - into +.
    public void RotateState(int characterNum)
    {
        if (state[characterNum, 0] == 0 || state[characterNum, 0] == 1)
        {
            state[characterNum, 0] = state[characterNum, 0] + 2;
        }
        else
        {
            state[characterNum, 0] = state[characterNum, 0] - 2;
        }
        if (state[characterNum, 1] == 0 || state[characterNum, 1] == 1)
        {
            state[characterNum, 1] = state[characterNum, 1] + 2;
        }
        else
        {
            state[characterNum, 1] = state[characterNum, 1] - 2;
        }
    }
}

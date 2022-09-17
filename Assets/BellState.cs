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
    
    //Inverts the current state, turns 0 into 1, 1 into 0.
    public void XGate(int characterNum)
    {
        if (state[characterNum, 0] == 0)
        {
            state[characterNum, 0] = state[characterNum, 0] + 1;
        }
        else if (state[characterNum, 0] == 1)
        {
            state[characterNum, 0] = state[characterNum, 0] - 1;
        }

        if (state[characterNum, 1] == 0)
        {
            state[characterNum, 1] = state[characterNum, 1] + 1;
        }
        else if (state[characterNum, 1] == 1)
        {
            state[characterNum, 1] = state[characterNum, 1] - 1;
        }
    }

    //Inverts the current state in the +- basis, turns + into -, - into +.
    public void YGate(int characterNum)
    {
        if (state[characterNum, 0] == 2)
        {
            state[characterNum, 0] = state[characterNum, 0] + 1;
        }
        else if (state[characterNum, 0] == 3)
        {
            state[characterNum, 0] = state[characterNum, 0] - 1;
        }

        if (state[characterNum, 1] == 2)
        {
            state[characterNum, 1] = state[characterNum, 1] + 1;
        }
        else if (state[characterNum, 1] == 3)
        {
            state[characterNum, 1] = state[characterNum, 1] - 1;
        }
    }

    //Rotates the state, turns 0 into +, + into 0, 1 into -, and - into +.
    public void HGate(int characterNum)
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

    //Player stepping on CNOT is target and other is the control player
    public void CNOTGate(int targetNum, int controlNum)
    {
        if (state[controlNum, 0] == 1)
        {
            if (state[targetNum, 0] == 0)
            {
                state[targetNum, 0] = state[targetNum, 0] + 1;
            }
            else
            {
                state[targetNum, 0] = state[targetNum, 0] - 1;
            }
        }

        if (state[controlNum, 1] == 1)
        {
            if (state[targetNum, 1] == 0)
            {
                state[targetNum, 1] = state[targetNum, 1] + 1;
            }
            else
            {
                state[targetNum, 1] = state[targetNum, 1] - 1;
            }
        }
    }
}

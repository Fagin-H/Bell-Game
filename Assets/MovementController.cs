using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovementController : MonoBehaviour
{
    //Gives each character a number to identify them and which state or qubit they relate to
    [SerializeField]
    public int characterNum;
    //Gives access to the BellState values
    [SerializeField]
    private BellState bellState;

    //Gives access to the tilemap and tiles so it can make changes as the player moves.
    public WinConChecker winCon;
    public Tile correctTile;
    public Tile targetTile;
    public Tile wrongTile;
    public Tilemap targetTilemap;
    public Tilemap currentTilemap;

    // Start is called before the first frame update
    void Start()
    {
        ReplaceTile();
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
        ReplaceTile();
    }

    //At the start and every time the character moves the tiles will be updated
    private void ReplaceTile()
    {
        //Get the current tiles for the target tilemap and the current tilemap
        Vector3Int currentCellTarget = targetTilemap.WorldToCell(transform.position);
        Vector3Int currentCellCurrent = currentTilemap.WorldToCell(transform.position);

        if (targetTilemap.GetTile<Tile>(currentCellTarget) == wrongTile)
        {
            //If a character goes over an incorrect tile they fail the level and the tile is replaced with null so you can see the red tile underneath
            winCon.hasFailed = true;
            currentTilemap.SetTile(currentCellCurrent, null);
        }
        else if (currentTilemap.GetTile<Tile>(currentCellCurrent) == null && targetTilemap.GetTile<Tile>(currentCellTarget) == targetTile)
        {
            //if they dont go over an incorrect tile and the new tile has not alread been walked on before, the tile is replaced with a yellow tile and the number of correct tiles is increased
            currentTilemap.SetTile(currentCellCurrent, correctTile);
            winCon.correctTiles += 1;
        }
        //Checks to see if the player won or lost after the movement
        winCon.CheckWin();
    }
}

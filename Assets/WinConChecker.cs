using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WinConChecker : MonoBehaviour
{
    public bool hasFailed = false;
    public int patternLength;
    public int correctTiles = 0;
    public Tilemap targetTilemap;
    public EndMenu endMenu;
    // Start is called before the first frame update
    void Start()
    {
        //Counts the number of targert tiles in the target tilemap. Thus telling you how many tiles need to be walked over in order to win
        int amount = 0;

        // loop through all of the tiles        
        BoundsInt bounds = targetTilemap.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            Tile tile = targetTilemap.GetTile<Tile>(pos);
            if (tile != null)
            {
                amount += 1;
            }
        }
        patternLength = amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckWin()
    {
        //Displays a message if you win or lose
        if (hasFailed)
        {
            endMenu.End(false);
        }
        else if (correctTiles == patternLength)
        {
            endMenu.End(true);
        }
       
    }
}

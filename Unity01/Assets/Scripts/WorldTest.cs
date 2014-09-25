using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldTest : MonoBehaviour
{
    private const int rowCount = 10;
    private const int columnCount = 10;
    private const int spacing = 50;
    private GameObject[][] testArray; // is an array of 'arrays of GameObjects'

    // Use this for initialization
    void Start()
    {
        CreateWorld();
        GameObject ball = (GameObject)Instantiate((Resources.Load("Unit01")));  
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject CreateTile(Vector3 position)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        GameObject tile = (GameObject)Instantiate((Resources.Load("Tile")), position, rotation);
        return tile;
    }

    private void CreateWorld()
    {
        testArray = new GameObject[rowCount][]; // is an array of 'arrays of 10 GameObjects'
        
        for (int i = 0; i < rowCount; i++)
        {
            testArray [i] = new GameObject[columnCount]; // there are 10 arrays of 'arrays of 10 GameObjects'
            for (int j = 0; j < columnCount; j++)
            {
                testArray [i] [j] = CreateTile(new Vector3(i * spacing, 0, j * spacing));
                testArray [i] [j].gameObject.GetComponent<Tile>().AssignIndex(i, j);
            }
        }
    }

    public void CalculateMoveDistance(GameObject tile, int moveSpeed)
    {
        int startingColumn = tile.GetComponent<Tile>().column;
        int startingRow = tile.GetComponent<Tile>().row;


        for (int i = 1; i <= moveSpeed; i++)
        {
            CheckDirection(startingColumn, startingRow+i); // up
            CheckDirection(startingColumn, startingRow-i); // down
            CheckDirection(startingColumn-i, startingRow); // left
            CheckDirection(startingColumn+i, startingRow); // right
        }
    }

    private void CheckDirection(int i, int j)
    {
        //testArray [i] [j].GetComponent<Tile>().PingTile();
    }

    private List<GameObject> NeighboringTiles(int i, int j)
    {
        List<GameObject> neighbors = new List<GameObject>();

        if (j + 1 <= 9)
        {
            neighbors.Add(testArray [i] [j + 1]);
        }
        if (j - 1 >= 0)
        {
            neighbors.Add(testArray [i] [j - 1]);
        }
        if (i - 1 >= 0)
        {
            neighbors.Add(testArray [i - 1] [j]);
        }
        if (i + 1 <= 9)
        {
            neighbors.Add(testArray [i + 1] [j]);
        }
        return neighbors;
    }

    public void FindReachableTiles(GameObject startingTile, int moveSpeed)
    {
        List<GameObject> mainList = new List<GameObject>();
        List<GameObject> tempList = new List<GameObject>();
        tempList.Add(startingTile);

        for (int passCount = 1; passCount <= moveSpeed; passCount++)
        {
            List<GameObject> newList = new List<GameObject>();
            for (int i = 0; i < tempList.Count; i++)
            {
                List<GameObject> testList = NeighboringTiles(tempList[i].GetComponent<Tile>().column, tempList[i].GetComponent<Tile>().row); // neighbors' neighbors
                foreach (GameObject tile in testList)
                {
                    if (!mainList.Contains(tile))
                    {
                        mainList.Add(tile);
                        newList.Add(tile); // neighbors' neighbors' neighbors
                    }
                }
            }
            tempList = newList;
        }

        foreach (GameObject tile in mainList)
        {
            tile.GetComponent<Tile>().PingTile();
        }
    }





}

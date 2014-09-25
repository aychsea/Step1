using UnityEngine;
using System.Collections;

public class TestUnit : MonoBehaviour
{
    private GameObject World;
    private int moveSpeed = 3;
    public bool bSelected = false;
    public GameObject currentTile;


    // Use this for initialization
    void Start()
    {
        World = GameObject.FindGameObjectWithTag("World");
        currentTile = null;
    }
    
    // Update is called once per frame
    void Update()
    {
            
    }

    public void SelectSphere()
    {
        bSelected = true;
        (gameObject.GetComponent("Halo") as Behaviour).enabled = true;
    }

    public void Deselect()
    {
        bSelected = false;
        (gameObject.GetComponent("Halo") as Behaviour).enabled = false;
    }

    public void MoveUnit(GameObject tile)
    {
        if (tile == currentTile)
        {
            print("I'm already here");
        } 
        else
        {
            Vector3 destination = tile.transform.position;
            gameObject.transform.position = destination;

            currentTile = tile;
        }
    }

    public void DetermineMoveDistance()
    {
        if (currentTile != null) World.GetComponent<WorldTest>().FindReachableTiles(currentTile, moveSpeed);
    }





}

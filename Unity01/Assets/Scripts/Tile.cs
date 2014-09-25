using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    private int pingDuration = 1;

    public int row;
    public int column;


    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
            
    }

    public void SelectTile()
    {
        //print("Column: " + column);
        //print("Row: " + row);
    }

    public void Deselect()
    {

    }

    public void AssignIndex(int i, int j)
    {
        column = i;
        row = j;
    }

    public void PingTile()
    {
        StartCoroutine(HighlightTile(pingDuration));
    }

    private IEnumerator HighlightTile(int duration)
    {
        (gameObject.GetComponent("Halo") as Behaviour).enabled = true;
        yield return new WaitForSeconds(pingDuration);
        (gameObject.GetComponent("Halo") as Behaviour).enabled = false;
    }


}

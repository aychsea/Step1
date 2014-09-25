using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour
{

    private GameObject selectedUnit;
    private GameObject mainCamera;


    // Use this for initialization
    void Start()
    {
        selectedUnit = null;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            mainCamera.GetComponent<CameraController>().MoveCameraUp();
        }
        if (Input.GetKey(KeyCode.S))
        {
            mainCamera.GetComponent<CameraController>().MoveCameraDown();
        }
        if (Input.GetKey(KeyCode.A))
        {
            mainCamera.GetComponent<CameraController>().MoveCameraLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            mainCamera.GetComponent<CameraController>().MoveCameraRight();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //if (NotUI)
                if (hit.transform.tag == "MovingSphere")
                {
                    TestUnit testUnit = hit.transform.gameObject.GetComponent<TestUnit>();
                    if (testUnit.bSelected)
                    {
                        testUnit.DetermineMoveDistance();
                    }
                    else 
                    {
                        DeselectAll();
                        testUnit.SelectSphere();
                        selectedUnit = hit.transform.gameObject;
                    }
                }
                else if (hit.transform.tag == "GroundPlane")
                {
                    DeselectAll();
                    Tile tile = hit.transform.gameObject.GetComponent<Tile>();
                    tile.SelectTile();
                }
                else print("I clicked on something new");
            }
            else DeselectAll();
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (selectedUnit != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "GroundPlane")
                    {   
                        selectedUnit.GetComponent<TestUnit>().MoveUnit(hit.transform.gameObject);
                    } 
                }
                else
                {
                    print("Tile not clicked");
                }
            }
        }
    }

    void DeselectAll()
    {
        if (selectedUnit != null)
        {
            GameObject[] unitList = GameObject.FindGameObjectsWithTag("MovingSphere");
            for (int i = 0; i < unitList.Length; i++)
            {
                if (unitList [i].GetComponent<TestUnit>().bSelected)
                {
                    unitList [i].GetComponent<TestUnit>().Deselect();
                }
            }

            selectedUnit = null;
        }
    }
}


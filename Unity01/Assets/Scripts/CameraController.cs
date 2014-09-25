using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private int camSpeed = 100;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    public void MoveCameraUp()
    {
        transform.Translate(0, Time.deltaTime * camSpeed, 0);
    }

    public void MoveCameraDown()
    {
        transform.Translate(0, -Time.deltaTime * camSpeed, 0);
    }

    public void MoveCameraLeft()
    {
        transform.Translate(-Time.deltaTime * camSpeed, 0, 0);
    }

    public void MoveCameraRight()
    {
        transform.Translate(Time.deltaTime * camSpeed, 0, 0);
    }
}

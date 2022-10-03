using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController click;
    public Transform target;
    private float startFOV, targetFOV;
    public float zoomSpeed;
    public Camera cam;
    private void Awake()
    {
     click = this;
    }
    // Start is called before the first frame update
    void Start()
    {
     startFOV = cam.fieldOfView;
     targetFOV = startFOV;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
     transform.position = target.position;
     transform.rotation = target.rotation; 
     cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
    }
    public void ZoomIn(float newZoom) 
    {
     targetFOV = newZoom;
    }
    public void ZoomOut() 
    {
     targetFOV = startFOV;
    }
}

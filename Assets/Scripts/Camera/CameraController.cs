using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dragSpeed = 2f;           
    public float zoomSpeed = 2f;           
    public float minZoom = 5f;             
    public float maxZoom = 20f;            

    private Vector3 dragOrigin;            

    void Update()
    {
        HandleMouseDrag();                 
        HandleZoom();                      
    }

    
    private void HandleMouseDrag()
    {
        if (Input.GetMouseButtonDown(0))   
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (Input.GetMouseButton(0))       
        {
            
            Vector3 difference = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);

            
            
            Vector3 move = new Vector3(difference.x * dragSpeed, 0, difference.y * dragSpeed);

            
            Vector3 moveWorldSpace = transform.right * move.x + transform.forward * move.z;
            
            moveWorldSpace.y = 0;
            transform.Translate(moveWorldSpace, Space.World);
            
            dragOrigin = Input.mousePosition;
        }
    }

    
    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");  
        if (scroll != 0.0f)
        {
            Camera.main.orthographicSize -= scroll * zoomSpeed;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom); 
        }
    }
}

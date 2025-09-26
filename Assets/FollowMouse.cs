using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LayerMask groundMask; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowerToMouse();
    }
    void MoveTowerToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, groundMask))
        {
            Vector3 newPos = hit.point;
            newPos.y = 0; 
            transform.position = newPos;
        }
    }
}

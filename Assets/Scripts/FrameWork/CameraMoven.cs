using UnityEngine;

public class EdgeCameraMovement : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 10f; 

    public Vector2 xLimit = new Vector2(-50f, 50f); // minX, maxX
    public Vector2 zLimit = new Vector2(-30f, 80f); // minZ, maxZ (your “Y” forward axis)

    public float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        Vector3 newPos = targetPos;

        // Mouse edge detection
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            newPos.z += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= panBorderThickness)
        {
            newPos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            newPos.x += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= panBorderThickness)
        {
            newPos.x -= panSpeed * Time.deltaTime;
        }

        // Clamp separately with min/max
        newPos.x = Mathf.Clamp(newPos.x, xLimit.x, xLimit.y);
        newPos.z = Mathf.Clamp(newPos.z, zLimit.x, zLimit.y);

        targetPos = newPos;

        // Smooth move toward target
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
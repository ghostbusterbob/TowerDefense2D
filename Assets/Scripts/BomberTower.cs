using System;
using UnityEngine;

public class BomberTower : MonoBehaviour
{

    public bool towerSelected = false;
    private TowerStatus towerStatus;

    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private int bulletForce;

    [SerializeField] private Transform laser;

    [Header("Trajectory Preview")]
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int linePoints = 30; // number of points in the arc
    [SerializeField] private float flightTime = 2f;

    private void Start()
    {
        
        towerStatus = GetComponent<TowerStatus>();

        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.05f;
            lineRenderer.endWidth = 0.05f;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.startColor = Color.yellow;
            
            lineRenderer.endColor = Color.red;
        }
        
        lineRenderer.enabled = false;
    }

    void Update()
    {
        VisualEffectShootPoint();

        if (Input.GetKeyDown(KeyCode.Mouse0) && towerStatus.towerPlaced && towerSelected )
        {
            Shoot();
        }
    }

    private void VisualEffectShootPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            shootPoint.LookAt(hit.point);
            if (towerStatus.towerPlaced && towerSelected)
                lineRenderer.enabled = true;
            DrawTrajectory(shootPoint.position, hit.point, flightTime);
        }
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, 100f)) return;

        Transform bulletInstance = Instantiate(bulletTransform, shootPoint.position, Quaternion.identity);
        Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();

        Vector3 launchVelocity = CalculateLaunchVelocity(hit.point, shootPoint.position, flightTime);

        rb.linearVelocity = launchVelocity;

        lineRenderer.enabled = false;

        towerSelected = false;
    }

    Vector3 CalculateLaunchVelocity(Vector3 target, Vector3 origin, float timeToTarget)
    {
        Vector3 displacement = target - origin;

        Vector3 displacementXZ = new Vector3(displacement.x, 0, displacement.z);

        float horizontalDistance = displacementXZ.magnitude;
        float verticalDistance = displacement.y;

        float horizontalSpeed = horizontalDistance / timeToTarget;
        float verticalSpeed = (verticalDistance / timeToTarget) - (0.5f * Physics.gravity.y * timeToTarget);

        Vector3 result = displacementXZ.normalized * horizontalSpeed;
        result.y = verticalSpeed;

        return result;
    }

    void DrawTrajectory(Vector3 origin, Vector3 target, float timeToTarget)
    {
        Vector3 velocity = CalculateLaunchVelocity(target, origin, timeToTarget);

        lineRenderer.positionCount = linePoints;

        for (int i = 0; i < linePoints; i++)
        {
            float t = (i / (float)(linePoints - 1)) * timeToTarget;
            Vector3 point = origin + velocity * t + 0.5f * Physics.gravity * t * t;
            lineRenderer.SetPosition(i, point);
        }
    }
}

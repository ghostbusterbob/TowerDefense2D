using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private WayPoints wayPoints;
    [SerializeField] private RespawnEnemy respawnEnemy;
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private float speed = 3f;    

    private HealthManager healthManager;    
    
    private List<Transform> points;
    private int currentIndex = 0;

    private void Start()
    {
        wayPoints = GameObject.FindGameObjectWithTag("WayPointHolder").GetComponent<WayPoints>();
        respawnEnemy = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RespawnEnemy>();
        
        healthManager = respawnEnemy.GetComponent<HealthManager>(); 
        
        if (wayPoints != null)
            points = wayPoints.GetWaypoints();
    }

    private void Update()
    {
        if (points == null || points.Count == 0) return;

        Transform target = points[currentIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            currentIndex++;

            if (currentIndex >= points.Count)
            {
                healthManager.DamageTower(10);
                
                RespawnEnemy();
                Destroy(gameObject);
            }
        }
    }

    public void RespawnEnemy()
    {
        respawnEnemy.SpawnEnemy(points[0].transform.position);
    }
}
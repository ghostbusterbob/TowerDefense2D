using System.Collections;
using UnityEngine;

public class ShootTower : MonoBehaviour
{
    [SerializeField] private TowerStatus towerStatus;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootingPoint;

    private float timer;
    [SerializeField]private Transform target;

    private bool shootingCooldown = true;
    
    
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Enemy").transform;
        } 

        
        transform.LookAt(target.transform);
        transform.Rotate(0, 180, 0);

        if (shootingCooldown)
        {
            timer += Time.deltaTime;

            if (timer >= fireRate)
            {
                timer = 0;
                shootingCooldown = false;
            }
        }

        if (!shootingCooldown && towerStatus.towerPlaced)
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
        shootingCooldown = true;
    }
}

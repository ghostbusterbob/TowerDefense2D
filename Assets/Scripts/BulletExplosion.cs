using System;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    [SerializeField] private GameObject fireExplosion;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionForce = 700f;

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(fireExplosion, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            EnemyHealth enemyHealth = nearbyObject.GetComponentInParent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.RemoveHealth(50);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
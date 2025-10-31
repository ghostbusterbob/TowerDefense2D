using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class BulletForce : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject enemy;
    [SerializeField] private int bulletForce;

    [SerializeField] private int damageAmount = 10;
    
    [SerializeField] private bool slowEffect;

    private EnemyMover enemyMover;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        transform.LookAt(enemy.transform.position);
        rb.AddForce(transform.forward * bulletForce * Time.deltaTime, ForceMode.Impulse);
        
        Destroy(gameObject, 20f);    
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.transform.GetComponent<EnemyHealth>().RemoveHealth(damageAmount);
            enemyMover = other.transform.GetComponent<EnemyMover>();
            StartCoroutine(RespawnEnemies(enemyMover));
            Destroy(gameObject);
        }
    }


    IEnumerator RespawnEnemies(EnemyMover enemy)
    {
        enemy.speed = 1f;
        yield return new WaitForSeconds(3);
        enemy.speed = enemy.initialSpeed;
    }
}

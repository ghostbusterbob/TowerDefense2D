using System;
using UnityEngine;

public class BulletForce : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject enemy;

    [SerializeField] private int bulletForce;
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
            //Destroy(gameObject);
        }
    }
}

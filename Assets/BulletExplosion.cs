using System;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject fireExplosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(fireExplosion, transform.position, transform.rotation);     
        Destroy(gameObject);
    }
}

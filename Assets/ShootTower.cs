using UnityEngine;

public class ShootTower : MonoBehaviour
{
    private Transform target;
    void Start()
    {
        
    }

    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        transform.LookAt(target.transform);
        transform.Rotate(0, 180, 0);    
    }
}

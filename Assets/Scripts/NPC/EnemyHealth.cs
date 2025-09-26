using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private EnemyMover enemyMover;
    //for respawning enemy
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            enemyMover.RespawnEnemy();
            Destroy(gameObject);
        }
    }

    public void RemoveHealth(int hp)
    {
        health -= hp;  
    }
}

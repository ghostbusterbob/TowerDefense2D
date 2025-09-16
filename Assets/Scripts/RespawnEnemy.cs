using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public void SpawnEnemy(Vector3 position)
    {
        Instantiate(enemy.transform,  position, Quaternion.identity); 
    }
}

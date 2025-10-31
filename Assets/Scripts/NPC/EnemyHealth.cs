using System;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private EnemyMover enemyMover;

    private CurrencyManager currencyManager;

    [SerializeField] private TextMeshProUGUI healthTxt;
    //for respawning enemy
    private void Start()
    {
        currencyManager = GameObject.Find("GameManager").GetComponent<CurrencyManager>();   
        UpdateEnemyUi();
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
            currencyManager.AddMoney(10);
            enemyMover.waveManager.DecreaseEnemies();
            Destroy(gameObject);
        }
    }

    public void RemoveHealth(int hp)
    {
        health -= hp;  
        UpdateEnemyUi();
    }

    private void UpdateEnemyUi()
    {
        healthTxt.text = health.ToString(); 
    }
}

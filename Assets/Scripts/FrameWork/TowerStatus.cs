using System;
using TMPro;
using UnityEngine;

public class TowerStatus : MonoBehaviour
{ 
   [SerializeField] private int health;
   [SerializeField] private TextMeshProUGUI healthText;  
   private int initialHealth; 
   public bool towerPlaced = false;
   private bool destroyed = false;
   

   public Transform towerPov;


   public int towerCost;

   private void Start()
   {
      initialHealth = health; 
   }

   private void Update()
   {
      CheckHealth();
   }

   private void CheckHealth()
   {
      if (health <= 0)
      {
         destroyed = true;
         Destroy(gameObject);
      }
   }
}

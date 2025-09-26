using System;
using UnityEngine;

public class TowerStatus : MonoBehaviour
{ 
   [SerializeField] private int health;
   private int initialHealth; 
   public bool towerPlaced = false;
   
   private bool destroyed = false;  

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

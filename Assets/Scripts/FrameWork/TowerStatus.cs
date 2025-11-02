using System;
using TMPro;
using UnityEngine;

public class TowerStatus : MonoBehaviour
{ 
   [SerializeField] private int health;
   [SerializeField] private TextMeshProUGUI healthText;
   [SerializeField] private GameObject TowerUi; 
   
   private int initialHealth; 
   public bool towerPlaced = false;
   private bool destroyed = false;

   public bool SpectatingTower;
   

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

   public void ToggleUi()
   {
      TowerUi.SetActive(!TowerUi.activeSelf);
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

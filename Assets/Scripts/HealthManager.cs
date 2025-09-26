using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    private float health;
    private float targetHealth; 
    [SerializeField] private float lerpSpeed = 5f;

    private void Start()
    {
        health = 100;
        targetHealth = health;
        healthSlider.maxValue = 100;
        healthSlider.value = health;
    }

    public void DamageTower(float damage)
    {
        health -= damage;
        targetHealth = health;  
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void Update()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, targetHealth, Time.deltaTime * lerpSpeed);
    }
}
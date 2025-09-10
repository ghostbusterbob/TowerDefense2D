using System;
using UnityEngine;

public class TowerIcon : MonoBehaviour
{

    private Vector3 originalScale;
    private bool shouldIncrease;

    private void Start()
    {
        originalScale = transform.localScale;   
    }

    private void Update()
    {
        if (shouldIncrease)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * 1.2f, Time.deltaTime * 20f);   
        } else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * 20f); 
        }
    }

    public void HoverOver()
    {
        shouldIncrease = true;  
    }

    public void ResetScale()
    {
        shouldIncrease = false; 
    }
}

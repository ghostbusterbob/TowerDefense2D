using System;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private void Update()
    {
        
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);    
    }
}

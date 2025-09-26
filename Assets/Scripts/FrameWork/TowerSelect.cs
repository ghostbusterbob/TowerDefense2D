using UnityEngine;
using System.Collections.Generic;

public class TowerSelect : MonoBehaviour
{
    [SerializeField] private Camera cam;
    
    [SerializeField] public List<GameObject> towers;

    public int selectedIndex;
    

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (hit.transform.CompareTag("TowerGrid"))
            {
                hit.transform.gameObject.SetActive(false);
                
                GameObject selectedTower = towers[selectedIndex]; 
                
                Instantiate(selectedTower.gameObject, hit.transform.position, hit.transform.rotation);  

            }
            
        }
    }

    public void SelectTower(int index)
    {
        selectedIndex = index;  
        Debug.Log("Tower " + index); 
    }
}

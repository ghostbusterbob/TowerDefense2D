using System.Collections;
using UnityEngine;

public class TowerSelected : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    BomberTower towerSelect;    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckTower();
        }
    }

    private void CheckTower()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.transform.GetComponent<BomberTower>())
            {
                 towerSelect = hit.transform.GetComponent<BomberTower>();
                 StartCoroutine(RearmTower());
            }
        }
    }

    private IEnumerator RearmTower()
    {
        yield return new WaitForSeconds(0.01f);
        towerSelect.towerSelected = true;
    }
}

using System.Collections;
using UnityEngine;

public class DragTower : MonoBehaviour
{
    [SerializeField] private TowerSelect towerSelect;
    
    private GameObject currentTower;   
    public GameObject towerPrefab;     
    public LayerMask groundMask;

    [SerializeField] private LayerMask gridMask;

    [SerializeField] private CurrencyManager currencyManager;   
    void Update()
    {
        if (currentTower != null)
        {
            MoveTowerToMouse();
            
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(TowerPlaced());
            }
        }
        
    }

    public void StartDraggingTower()
    {
        towerPrefab = towerSelect.towers[towerSelect.selectedIndex];


        if (currencyManager.money >= towerPrefab.GetComponent<TowerStatus>().towerCost)
        {
            currentTower = Instantiate(towerPrefab);
        } else
        {
            towerPrefab = null;
        }

            
    }

    void MoveTowerToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, groundMask))
        {
            Vector3 newPos = hit.point;
            newPos.y = 0; 
            currentTower.transform.position = newPos;
        }
    }

    IEnumerator TowerPlaced()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 100f, gridMask))
        {
            currentTower.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + .5f, hit.transform.position.z);
            
            TowerStatus towerStatus = currentTower.GetComponent<TowerStatus>(); 
            currencyManager.RemoveMoney(towerStatus.towerCost);

            currentTower = null; 
            yield return new WaitForSeconds(1);
            towerStatus.towerPlaced = true; 
        } 
        
        
    }
}
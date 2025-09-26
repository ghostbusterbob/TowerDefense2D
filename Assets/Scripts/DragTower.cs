using System.Collections;
using UnityEngine;

public class DragTower : MonoBehaviour
{
    [SerializeField] private TowerSelect towerSelect;
    
    private GameObject currentTower;   
    public GameObject towerPrefab;     
    public LayerMask groundMask;       

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
        currentTower = Instantiate(towerPrefab);
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
        TowerStatus towerStatus = currentTower.GetComponent<TowerStatus>(); 
        currentTower = null; 
        yield return new WaitForSeconds(1);
        towerStatus.towerPlaced = true; 
    }
}
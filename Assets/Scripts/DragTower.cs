using UnityEngine;

public class DragTower : MonoBehaviour
{
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
                TowerStatus towerStatus = currentTower.GetComponent<TowerStatus>(); 
                towerStatus.towerPlaced = true; 
                currentTower = null; 
            }
        }
        
    }

    public void StartDraggingTower()
    {
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
}
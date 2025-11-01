using System.Collections;
using UnityEngine;

public class TowerSelected : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private EdgeCameraMovement edgeCameraMovement;
    
    BomberTower towerSelect;
    private TowerStatus towerStatus;
    private bool lerpCam = false;
    private bool lerpInitial = false;

    private Vector3 initialCameraPos;
    private Quaternion initialCameraRot;
    private bool savedPosRot = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckTower();
        }

        if (lerpCam)
        {
            if (!savedPosRot)
            {
                initialCameraPos = Camera.main.transform.position;
                initialCameraRot = Camera.main.transform.rotation;
                
                savedPosRot = true;
            }
            
            
            Camera.main.transform.position = Vector3.Lerp(
                Camera.main.transform.position,
                towerStatus.towerPov.transform.position + new Vector3(0, 0.5f, 0),
                7f * Time.deltaTime
            );
            Camera.main.transform.rotation = Quaternion.Lerp(
                Camera.main.transform.rotation,
                towerStatus.towerPov.transform.rotation * Quaternion.Euler(0, 180f, 0),
                7f * Time.deltaTime
            );

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                lerpInitial = true;
                lerpCam = false;
            }
        }

        if (lerpInitial)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, initialCameraPos, 10f * Time.deltaTime);
            Camera.main.transform.rotation = Quaternion.Lerp(
                Camera.main.transform.rotation,
                initialCameraRot,
                10f * Time.deltaTime
            );

            float posDiff = Vector3.Distance(Camera.main.transform.position, initialCameraPos);
            float rotDiff = Quaternion.Angle(Camera.main.transform.rotation, initialCameraRot);

            if (posDiff < 0.01f && rotDiff < 0.5f)
            {
                Camera.main.transform.position = initialCameraPos;
                Camera.main.transform.rotation = initialCameraRot;

                lerpInitial = false;
                savedPosRot = false;
                edgeCameraMovement.enabled = true; 
            }
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

            if (hit.transform.CompareTag("NonSpecial"))
            {
               edgeCameraMovement.enabled = false;   
                
               towerStatus = hit.transform.GetComponent<TowerStatus>();
               lerpCam = true;
            }
        }
    }

    private IEnumerator RearmTower()
    {
        yield return new WaitForSeconds(0.01f);
        towerSelect.towerSelected = true;
    }
}

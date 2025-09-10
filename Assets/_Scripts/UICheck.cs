using UnityEngine;

public class BottomQuarterDetector : MonoBehaviour
{
    [SerializeField] private RectTransform uiElement;
    [SerializeField] private float moveUpAmount = 50f; 
    [SerializeField] private float moveSpeed = 3f;

    private Vector2 originalPos;
    private Vector2 targetPos;

    void Start()
    {
        // remember where the panel starts
        originalPos = uiElement.anchoredPosition;
        targetPos = originalPos;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        if (mousePos.y <= Screen.height * 0.25f)
        {
            targetPos = originalPos + new Vector2(0, moveUpAmount);
        }
        else
        {
            targetPos = originalPos;
        }

        uiElement.anchoredPosition = Vector2.Lerp(
            uiElement.anchoredPosition,
            targetPos,
            moveSpeed * Time.deltaTime
        );
    }
}
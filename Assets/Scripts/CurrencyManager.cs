using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyTxt;
    [SerializeField] public int money;

    private float displayedMoney;

    private void Start()
    {
        displayedMoney = money;
        moneyTxt.text = "$: " + money;
    }

    private void Update()
    {
        displayedMoney = Mathf.Lerp(displayedMoney, money, Time.deltaTime * 10f);
        moneyTxt.text = "$: " + Mathf.RoundToInt(displayedMoney);
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
    }
}
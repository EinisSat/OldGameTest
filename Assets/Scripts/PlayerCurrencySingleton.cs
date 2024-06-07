using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrencySingleton : MonoBehaviour
{
    [SerializeField] private int currency = 0;
	[SerializeField] TextMeshProUGUI textUGUI;
	private string text;

	private void Awake()
	{
		textUGUI.SetText("0");
	}
	public void AddCurrency(int amount)
	{
		currency += amount;
		Refresh();
	}
	public void LoseCurrency(int amount)
	{
		if(currency - amount < 0) currency = 0;
		else currency += amount;
		Refresh();
	}
	private void Refresh()
	{
		textUGUI.SetText(currency.ToString());
	}
}

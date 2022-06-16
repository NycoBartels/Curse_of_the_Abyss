using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int crystalAmount;
    private GameObject inventory;
    private TextMeshProUGUI crystalText;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("InvUI");
        crystalText = inventory.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (crystalAmount >= 1)
        {
            inventory.SetActive(true);
        } else
        {
            inventory.SetActive(false);
        }
        crystalText.SetText(crystalAmount.ToString());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayAttribute : MonoBehaviour
{
    public AttributeType typeToDisplay;
    public TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
       text.text = ($"{typeToDisplay.ToString()} : {InventoryManager.Instance.player.GetAttributeValue(typeToDisplay)}");
    }
}

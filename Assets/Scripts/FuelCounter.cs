using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelCounter : MonoBehaviour
{
    public TMP_Text DisplayText; // Reference to the TextMeshPro component
    private int _count = 0;

    public void Count()
    {
        ++_count;
        DisplayText.text = _count.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo_BestCombo : MonoBehaviour
{
    public Text button_Combo;
    public Text button_bestCombo;

    void Start()
    {
        button_Combo.text = "Combo: " + Save_PlayerPrefabs.Get_SoCombo();
        button_bestCombo.text = "Hight Combo: " + Save_PlayerPrefabs.Get_Hight_Combo();
    }
}

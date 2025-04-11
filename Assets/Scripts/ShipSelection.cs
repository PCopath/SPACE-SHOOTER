using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelection : MonoBehaviour
{
    public void SelectShip(int shipIndex)
    {
        PlayerPrefs.SetInt("SelectedShip", shipIndex);
        PlayerPrefs.Save();
        Debug.Log("Seçilen gemi: " + shipIndex);
    }
}

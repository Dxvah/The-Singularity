using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brillo : MonoBehaviour
{
    public Slider brillo;
    public float brilloValue;
    public Image panelBrillo;
    void Start()
    {
        brillo.value = PlayerPrefs.GetFloat("brillo", 0.3f);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, brillo.value);
    }

    public void ChangeScrollbar(float value)
    {
        brillo.value = value;
        PlayerPrefs.SetFloat("brillo", value);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, value);
    }
}

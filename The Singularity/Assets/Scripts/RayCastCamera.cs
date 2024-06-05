using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastCamera : MonoBehaviour
{
    public Image mira; 
    public Camera cam; 

    void Start()
    {
        
        if (cam == null)
        {
            cam = Camera.main;
        }

        if (mira == null)
        {
            Debug.LogError("No se ha asignado la imagen de la mira.");
        }
    }

    void Update()
    {
        if (mira == null || cam == null)
        {
            return; 
        }

        
        mira.color = new Color(mira.color.r, mira.color.g, mira.color.b, 0.4f);

        
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit))
        {
            mira.color = new Color(mira.color.r, mira.color.g, mira.color.b, 1f);
            Debug.Log("Elemento encontrado: " + hit.collider.name);
        }
    }
}

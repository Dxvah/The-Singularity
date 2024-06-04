using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControler : MonoBehaviour
{
    public GameObject menuPrincipalCanvas;
    public GameObject menuOpcionesCanvas;
    

    void Start()
    {

        menuPrincipalCanvas.SetActive(true);
        menuOpcionesCanvas.SetActive(false);
    }

    public void CambiarMenu()
    {

        menuPrincipalCanvas.SetActive(false);
        menuOpcionesCanvas.SetActive(true);
    }

    public void VolverAlMenu()
    {

        menuOpcionesCanvas.SetActive(false);
        menuPrincipalCanvas.SetActive(true);
    }
}

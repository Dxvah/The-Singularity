using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastCamera : MonoBehaviour
{
    public Image mira;
    public Camera cam;
    public float raycastDistance = 100f;
    public LayerMask enemyLayerMask;
    private Enemigo enemigo;

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
        if (mira == null || cam == null || enemigo == null)
        {
            return;
        }

        mira.color = new Color(mira.color.r, mira.color.g, mira.color.b, 0.4f);

        Ray ray = cam.ScreenPointToRay(cam.transform.position);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            mira.color = new Color(mira.color.r, mira.color.g, mira.color.b, 1f);
            Debug.Log("Elemento encontrado:");
Debug.Log(hit);
            Enemigo enemyCol = hit.collider.GetComponent<Enemigo>();
            if (enemyCol != null)
            {
                enemyCol.SetBeingWatched(true);
            }
            else
            {
                enemyCol.SetBeingWatched(false);
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(cam.transform.position, transform.forward);
    }
}





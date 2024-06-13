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
    [SerializeField]
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
        if (mira == null || cam == null)
        {
            return;
        }

        mira.color = new Color(mira.color.r, mira.color.g, mira.color.b, 0.4f);

        //Ray ray = cam.ScreenPointToRay(cam.transform.position);
        //Ray ray = new Ray(mira.transform.position, mira.transform.forward);

        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen

        // actual Ray
        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            mira.color = new Color(mira.color.r, mira.color.g, mira.color.b, 1f);
            Debug.Log(hit.collider.gameObject.name);

            if (LayerMask.LayerToName(hit.collider.gameObject.layer) == "enemy")
            {
                // enemyAwake = true
                enemigo = hit.collider.gameObject.GetComponent<Enemigo>();
                enemigo.SetBeingWatched(true);
            }
            else
            {
                     if(enemigo != null)
                        {
                            Debug.Log("Muevete");
                            enemigo.SetBeingWatched(false);
                        }
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
        float rayLength = 500f;

        // actual Ray
        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

        Gizmos.DrawRay(ray);
    }
}





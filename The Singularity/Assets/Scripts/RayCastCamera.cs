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
    public LayerMask interactuableLayerMask;
    [SerializeField]
    private Enemigo enemigo;

    public bool hasCogidoElObjeto = false;

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

        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
           

            if (LayerMask.LayerToName(hit.collider.gameObject.layer) == "enemy")
            {
                mira.color = new Color(mira.color.r, mira.color.g, mira.color.b, 1f);
                enemigo = hit.collider.gameObject.GetComponent<Enemigo>();
                enemigo.SetBeingWatched(true);
            }
            else
            {
                if (enemigo != null)
                {
                    enemigo.SetBeingWatched(false);
                }
            }

            if (LayerMask.LayerToName(hit.collider.gameObject.layer) == "interactuable")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    mira.color = new Color(mira.color.r, mira.color.g, mira.color.b, 1f);
                    hasCogidoElObjeto = true;
                    Debug.Log("Objeto interactuable cogido!");
                    Destroy(hit.collider.gameObject); 
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f);
        float rayLength = 500f;

        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
        Gizmos.DrawRay(ray);
    }
}







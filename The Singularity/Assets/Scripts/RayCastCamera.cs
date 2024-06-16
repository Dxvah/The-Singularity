using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastCamera : MonoBehaviour
{
    public Image mira;
    public Camera cam;
    public float raycastDistance = 500f;
    public LayerMask enemyLayerMask;
    public LayerMask interactuableLayerMask;
    [SerializeField]
    private Enemigo enemigo;

    public bool hasCogidoElObjeto = false;
    public GameObject boca;  
    public Transform puntodeInstancia; 

    private int totalBurgers = 13;
    private int burgersCollected = 0;
    public GameObject canvas; 

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

        if (boca == null)
        {
            Debug.LogError("No se ha asignado el objeto para instanciar.");
        }

        if (puntodeInstancia == null)
        {
            Debug.LogError("No se ha asignado el punto de instanciación.");
        }

        if (canvas == null)
        {
            Debug.LogError("No se ha asignado el canvas.");
        }
        else
        {
            canvas.SetActive(false);
        }
    }

    void Update()
    {
        if (mira == null || cam == null)
        {
            return;
        }

        mira.color = new Color(mira.color.r, mira.color.g, mira.color.b, 0.4f);

        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f);
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

                    if (hit.collider.gameObject.name == "esposas")
                    {
                        Instantiate(boca, puntodeInstancia.position, puntodeInstancia.rotation);
                        Debug.Log("Objeto instanciado en el punto especificado!");
                    }
                    if (hit.collider.gameObject.CompareTag("burger"))
                    {
                        burgersCollected++;
                        Debug.Log("Hamburguesa recogida. Total recogidas: " + burgersCollected);

                        if (burgersCollected >= totalBurgers)
                        {
                            canvas.SetActive(true);
                            Debug.Log("Todas las hamburguesas han sido recogidas!");
                        }

                       
                    }
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

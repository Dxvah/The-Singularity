using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FadeTransicion : MonoBehaviour
{
    private Animator fadetrans;
    // Start is called before the first frame update
    void Start()
    {
        fadetrans = GetComponent<Animator>();
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(Transiciona(scene));
    }
    IEnumerator Transiciona(string scene)
    {
        fadetrans.SetTrigger("CambioEscena");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scene);
    }
}

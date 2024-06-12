using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Radio : MonoBehaviour
{
    public AudioSource limbo;
    private bool onTrigger = false;
    public TextMeshProUGUI textMeshPro;
    public float fadeDuration = 2.0f;
    public float displayDuration = 2.0f;

    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTrigger && !limbo.isPlaying)
        {
            limbo.Play();
        }
    }

    private void FadeInAndOut()
    {
        if (textMeshPro == null) return;
        Color color = textMeshPro.color;
        color.a = 0;
        textMeshPro.color = color;

        
        LeanTween.value(gameObject, 0f, 1f, fadeDuration).setOnUpdate((float val) =>
        {
            Color newColor = textMeshPro.color;
            newColor.a = val;
            textMeshPro.color = newColor;
        }).setOnComplete(() =>
        {
            
            LeanTween.delayedCall(displayDuration, () =>
            {
                
                LeanTween.value(gameObject, 1f, 0f, fadeDuration).setOnUpdate((float val) =>
                {
                    Color newColor = textMeshPro.color;
                    newColor.a = val;
                    textMeshPro.color = newColor;
                });
            });
        });
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            onTrigger = true;
            if (textMeshPro != null)
            {
                FadeInAndOut();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = false;
        }
    }
}


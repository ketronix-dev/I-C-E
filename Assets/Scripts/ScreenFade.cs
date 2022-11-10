using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    private Image fadeImage;
    void Start()
    {
        fadeImage = this.gameObject.GetComponent<Image>();
        fadeImage.canvasRenderer.SetAlpha(1.0f);
        fadeIn();
    }
    
    public void fadeIn()
    {
        fadeImage.CrossFadeAlpha(0,2,false);
        Invoke("Deactivate", 1.9f);
    }
    public void fadeOut()
    {
        Activate();
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1,1,false);
    }
    void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
    void Activate()
    {
        this.gameObject.SetActive(true);
    }
}
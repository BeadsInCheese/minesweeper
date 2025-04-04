using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLay1 : MonoBehaviour
{
    public Shader shader;
    private Material material;
    public Texture2D textTexture;
    // Start is called before the first frame update
    void OnEnable()
    {
        material = new Material(shader);
        material.SetTexture("_TextTexture", textTexture);
        material.hideFlags = HideFlags.HideAndDontSave;
    }
    private void OnDisable()
    {
        material = null;
    }
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination,material,0);
    }
}

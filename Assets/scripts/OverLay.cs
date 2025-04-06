using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLay : MonoBehaviour
{
    public Shader shader;
    private Material material;

    // Start is called before the first frame update
    void OnEnable()
    {
        material = new Material(shader);
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

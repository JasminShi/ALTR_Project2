using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControllerRed : MonoBehaviour
{
    // Start is called before the first frame update
    //MeshRenderer meshRenderer;
    private Color emissionColor;
    public float intensity;
    public Material material;

    //get required components
    private void Awake()
    {
        //get the mesh renderer
        //meshRenderer = GetComponent<MeshRenderer>();
        //get the emission color
        emissionColor = material.GetColor("_EmissionColor");
    }

    public void Flash()
    {
        StartCoroutine(StartFlashing());
    }

    //let it run every frame
    IEnumerator StartFlashing()
    {
        //let it run infinitely
        while (true)
        {
            // Enables emission for the material, and make the material use
            // realtime emission
            material.EnableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", Color.red*Mathf.PingPong(Time.time, intensity));
            yield return null;  //the above expression called every frame (similar to creating a background void Update()
        }
    }

    public void StopFlashing()
    {
        StopAllCoroutines();
        //set intensity of the emission color to a value
        intensity = 0;
    }

}

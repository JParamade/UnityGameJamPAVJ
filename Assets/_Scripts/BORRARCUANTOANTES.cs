using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BORRARCUANTOANTES : MonoBehaviour
{
    [SerializeField] float velocidadDeRotacione;

    void Start()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 3.0f);
    }
    void Update()
    {
        float actualRotation = RenderSettings.skybox.GetFloat("_Rotation");
        if(actualRotation > 215.0f)
        {
            velocidadDeRotacione = -velocidadDeRotacione;
        }
        if(actualRotation < 1.0f)
        {
            velocidadDeRotacione = -velocidadDeRotacione;
        }
        RenderSettings.skybox.SetFloat("_Rotation", actualRotation + Time.deltaTime * velocidadDeRotacione);
    }
}

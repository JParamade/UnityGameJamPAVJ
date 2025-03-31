using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Countadormetro : MonoBehaviour
{
    int frutillas = 0;
    [SerializeField] string eitiquieta;
    [SerializeField] Camera asfd;
    private void OnTriggerEnter(Collider other)
    {
        if(eitiquieta.Equals(other.tag))
        {
            ++frutillas;
        }
        print("tenemos " + frutillas + " " + eitiquieta);
    }

    private void OnTriggerExit(Collider other)
    {
        if (eitiquieta.Equals(other.tag))
        {
            --frutillas;
        }
        print("tenemos " + frutillas + " " + eitiquieta);
    }
}

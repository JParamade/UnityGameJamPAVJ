using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Countadormetro : MonoBehaviour
{
    [SerializeField] string eitiquieta;
    [SerializeField] Camera asfd;
    [SerializeField] GameObject balalacinin;
    private void OnTriggerEnter(Collider other)
    {
        if(eitiquieta.Equals(other.tag))
        {
            GameManager.Instance.AddPoints(1);
        }
        if(other.tag.Equals("Player"))
        {
            other.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
            balalacinin.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (eitiquieta.Equals(other.tag))
        {
            GameManager.Instance.AddPoints(-1);
        }
    }
}

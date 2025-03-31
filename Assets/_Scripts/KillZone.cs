using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] GameObject balalacinin;

    private void OnTriggerEnter(Collider other)
    {
        // && other.gameObject.tag == "Fruits"
        if (other != null)
        {
            if(other.tag.Equals("Player"))
            {
                other.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
                balalacinin.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            }
            else
            {
                Destroy(other.gameObject);
            }                
        }
    }
}

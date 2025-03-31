using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LA_BOMBA : MonoBehaviour
{
    [SerializeField] float radioExplo = 5;
    [SerializeField] float exploForce = 500;
    [SerializeField] float timeExplosion = 5;
    [SerializeField] GameObject particulililiulila;
    Coroutine Booooom;
    void Start()
    {
        Booooom = StartCoroutine(Explosion());
    }


    void Update()
    {
        
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(timeExplosion);
        Destroy( Instantiate(particulililiulila, transform.position, Quaternion.identity),5f);
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioExplo);
        foreach (Collider coll in colliders)
        {
            if (coll.GetComponent<Rigidbody>() != null)
            {
                coll.GetComponent<Rigidbody>().AddExplosionForce(exploForce, transform.position, radioExplo, 1);
            }
        }
        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radioExplo);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerManager : MonoBehaviour
{
    public float iSpeedSpawn;
    public float iDelaySpawn;
    public GameObject[] Fruits;
  

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", iSpeedSpawn, iDelaySpawn);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    void Spawn()
    {
        int index = Random.Range(0, Fruits.Length);
        Vector3 Position = new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2), transform.position.y, Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2));
        Instantiate(Fruits[index], Position, Quaternion.identity);
       
    }
}

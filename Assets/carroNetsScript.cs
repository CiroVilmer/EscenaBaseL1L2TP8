using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carroNetsScript : MonoBehaviour
{
    public GameObject computerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateComputer()
    {
        Instantiate(computerPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation);
    }
}

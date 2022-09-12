using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCbehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] CPUs;

    private bool playerOnRange = false;

    private GameObject canvas;
    [SerializeField] string[] dialogues;
    public TextMeshPro dialogueTxt;



    // Start is called before the first frame update
    void Start()
    {
        CPUs = GameObject.FindGameObjectsWithTag("Gabinete");

        for (int i = 0; i < 2; i++)
        {
            int seleccionarCPU = Random.Range(0, CPUs.Length);

            CPUs[seleccionarCPU].GetComponent<BoxCollider>().enabled = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnRange)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnRange = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnRange = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCbehaviour : MonoBehaviour
{

    [SerializeField] GameObject[] CPUs;

    private bool playerOnRange = false;

    //Dialogues

    public NPC NPCdata;
    [SerializeField] string[] dialogues;
    private int dialoguePosition = -1;

    //canvas
    [Header("NPC-UI")]
    public GameObject canvas;
    public TextMeshProUGUI dialogueTxt;



    // Start is called before the first frame update
    void Start()
    {
        dialogues = NPCdata.dialogues;

        CPUs = GameObject.FindGameObjectsWithTag("gabinete");

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



        if (Input.GetKeyDown(KeyCode.R) && playerOnRange)
        {
            dialoguePosition++;

            if (dialoguePosition < dialogues.Length)
            {
                dialogueTxt.text = dialogues[dialoguePosition];
            }
            else
            {
                bool once = true;
                if (once)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int seleccionarCPU = Random.Range(0, CPUs.Length);
                        int dificultadCPU = 1;

                        if (CPUs[seleccionarCPU].GetComponent<BoxCollider>().enabled == false)
                        {
                            BoxCollider cpuCollider = CPUs[seleccionarCPU].GetComponent<BoxCollider>();
                            cpuCollider.enabled = true;
                            cpuCollider.isTrigger = true;
                            CPUs[seleccionarCPU].GetComponent<cpuScript>().dificultad = dificultadCPU;
                            dificultadCPU++;
                        }
                        else
                        {
                            i--;
                        }
                    }
                    once = false;
                }

                dialogueTxt.text = "Cuando Termines avisame!";
            }
        }

    }

    void NextFrase()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerOnRange)
        {
            dialoguePosition++;

            if(dialoguePosition < dialogues.Length)
            {
                dialogueTxt.text = dialogues[dialoguePosition];
            }
            else
            {
                dialogueTxt.text = "Cuando Termines avisame!";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnRange = true;

            bool once = true;
            if (once)
            {
                dialogueTxt.text = "Hola Alumno";
                once = false;
            }
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

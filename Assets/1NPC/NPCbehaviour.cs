using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCbehaviour : MonoBehaviour
{

    [SerializeField] GameObject[] CPUs;

    private bool playerOnRange = false;
    private bool missionFinished = false;

    //Dialogues

    public NPC NPCdata;
    public GameObject door;
    [SerializeField] string[] dialogues;
    private int dialoguePosition = -1;
    public int CPUfixed = 0;

    //canvas
    [Header("NPC-UI")]
    public GameObject canvas;
    public TextMeshProUGUI dialogueTxt, nextTxt;



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

        if (!missionFinished)
        {
            if (Input.GetKeyDown(KeyCode.R) && playerOnRange)
            {
                dialoguePosition++;

                if (dialoguePosition < dialogues.Length)
                {
                    dialogueTxt.text = dialogues[dialoguePosition];
                }
                else if (dialoguePosition < dialogues.Length + 1)
                {

                        for (int i = 1; i < 4; i++)
                        {
                            int seleccionarCPU = Random.Range(0, CPUs.Length);

                            if (CPUs[seleccionarCPU].GetComponent<BoxCollider>().enabled == false)
                            {
                                BoxCollider cpuCollider = CPUs[seleccionarCPU].GetComponent<BoxCollider>();
                                cpuCollider.enabled = true;
                                cpuCollider.isTrigger = true;
                                CPUs[seleccionarCPU].GetComponent<cpuScript>().dificultad = i;

                            }
                            else
                            {
                                i--;
                            }

                    }

                    dialogueTxt.text = "Cuando Termines avisame!";
                }
                else
                {
                    dialogueTxt.text = "Cuando Termines avisame!";
                }
            }
        }

        if (missionFinished)
        {
            dialogueTxt.text = "Gracias por ayudarme alumno, te voy a subir la nota!!!";
            nextTxt.text = "";
            door.SetActive(false);
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

    public void computerFixed()
    {
        CPUfixed++;

        if(CPUfixed <= 3)
        {
            missionFinished = true;
        }
    }


}

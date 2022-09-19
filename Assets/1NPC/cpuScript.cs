using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cpuScript : MonoBehaviour
{
    //variables
    public int dificultad = 0;
    public int vidaRestante;
    public bool playerOnRange = false;
    private bool once = true;
    private bool doOnce = true;
    public GameObject zap;

    //Canvas
    public GameObject cpuCanvas;
    public GameObject healthCanvas;
    public GameObject avisos;
    private NPCbehaviour NPCcontroller;
    private healthBar healthBarController;
    public TextMeshProUGUI textCounter, cpuArreglada;

    // Start is called before the first frame update
    void Start()
    {

        healthBarController = healthCanvas.GetComponent<healthBar>();


        NPCcontroller = GameObject.Find("NPC").GetComponent<NPCbehaviour>();


    }

    // Update is called once per frame
    void Update()
    {

        if (playerOnRange)
        {
            cpuCanvas.SetActive(true);
            textCounter.text = vidaRestante.ToString();
            Debug.Log("Canvas ON");
        }

    }

    void OnMouseDown()
    {

        if(vidaRestante > 0){
            vidaRestante--;
            healthBarController.healthLeft--;
            textCounter.text = vidaRestante.ToString();


            GameObject clon = Instantiate(zap, this.transform);
            Destroy(clon, 0.5f);
        }
        else
        {

            if (doOnce)
            {
                NPCcontroller.computerFixed();
                doOnce = false;
            }

            string text = "COMPUTADORA ARREGLADA";
          
            textCounter.text = text;

            avisos.SetActive(true);

        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            playerOnRange = true;

            if (once)
            {
                if (dificultad == 1)
                {
                    vidaRestante = 10;
                }
                else if (dificultad == 2)
                {
                    vidaRestante = 30;
                }
                else if (dificultad == 3)
                {
                    vidaRestante = 50;
                }
                once = false;
            }


            healthBarController.updateHealth(vidaRestante);


            Debug.Log("Player in");
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnRange = false;
        }
        cpuCanvas.SetActive(false);
        avisos.SetActive(false);
    }
}

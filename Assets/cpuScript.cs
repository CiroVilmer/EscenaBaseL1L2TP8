using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cpuScript : MonoBehaviour
{
    //variables
    public int dificultad;
    public int vidaRestante;
    bool playerOnRange = false;

    //Canvas
    public GameObject cpuCanvas;
    public TextMeshProUGUI textCounter;

    // Start is called before the first frame update
    void Start()
    {
        cpuCanvas.SetActive(false);

        if(dificultad == 1)
        {
            vidaRestante = 10;
        }else if(dificultad == 2)
        {
            vidaRestante = 30;
        }else if(dificultad == 3)
        {
            vidaRestante = 50;
        }
        
    }

    // Update is called once per frame
    void Update()
    {



        if (playerOnRange)
        {
            cpuCanvas.SetActive(true);
            textCounter.text = vidaRestante.ToString();
        }
        else
        {
            cpuCanvas.SetActive(false);
        }

    }

    void OnMouseDown()
    {

        if(vidaRestante > 0){
            vidaRestante--;
            textCounter.text = vidaRestante.ToString();
        }
        else if(vidaRestante == 0)
        {
            textCounter.text = "COMPUTADORA ARREGLADA";
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

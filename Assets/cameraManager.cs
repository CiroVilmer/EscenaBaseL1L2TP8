using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public GameObject camIntro;
    public GameObject camPlayer;

    // Start is called before the first frame update
    void Start()
    {
        camIntro.SetActive(true);
        camPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraActivaion()
    {
        camIntro.SetActive(false);
        camPlayer.SetActive(true);
    }
}

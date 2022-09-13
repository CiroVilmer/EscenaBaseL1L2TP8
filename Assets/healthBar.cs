using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public float maxHealth;
    public float healthLeft;
    private Image HealthBar;
    // Start is called before the first frame update
    void Start()
    {
    
        HealthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        HealthBar.fillAmount = healthLeft / maxHealth;

    }

    public void updateHealth(int upHealth)
    {
        maxHealth = upHealth;
        healthLeft = maxHealth;


    }
}

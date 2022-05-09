using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar_Script : MonoBehaviour
{
    private Image PlayerHealthBar;
    

    public float PlayerCurrentHealth;
    

    private float PlayerMaxHealth = 100f;
    

    Health_Script PlayerHP;

   
    private void Awake() 
    {   
        //Find
        PlayerHealthBar = GetComponent<Image>();
        PlayerHP = FindObjectOfType<Health_Script>();
    }

    private void Start()
    {
        PlayerMaxHealth = PlayerHP.PlayerHealth;
       
    }

    private void Update()
    {
        PlayerCurrentHealth = PlayerHP.PlayerHealth;
        

        PlayerHealthBar.fillAmount = PlayerCurrentHealth / PlayerMaxHealth;
        
    }
}

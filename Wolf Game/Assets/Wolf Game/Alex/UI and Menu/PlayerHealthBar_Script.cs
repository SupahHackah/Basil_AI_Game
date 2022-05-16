using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar_Script : MonoBehaviour
{
    private Image PlayerHealthBar;
    

    public float PlayerCurrentHealth;
    

    private float PlayerMaxHealth = 100f;


    //Health_Script PlayerHP;

    Fox_Movement fox;

   
    private void Awake() 
    {   
        //Find
        PlayerHealthBar = GetComponent<Image>();
        //PlayerHP = FindObjectOfType<Health_Script>();
        fox = FindObjectOfType<Fox_Movement>();
    }

    private void Start()
    {
        PlayerMaxHealth = fox.player_Health;
       
    }

    private void Update()
    {
        PlayerCurrentHealth = fox.player_Health;
        

        PlayerHealthBar.fillAmount = PlayerCurrentHealth / PlayerMaxHealth;
        
    }
}

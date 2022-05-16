using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyHealthBar_Script : MonoBehaviour
{
    private Image AllyHealthBar;

   
    public float AllyCurrentHealth;

   
    private float AllyMaxHealth = 100f;

    //Health_Script AllyHP;
    Ally_Ai_Manager  _ally;

   
    private void Awake() 
    {   
        //Find
        AllyHealthBar = GetComponent<Image>();
        //AllyHP = FindObjectOfType<Health_Script>();
        _ally = FindObjectOfType<Ally_Ai_Manager>();
    }

    private void Start()
    {
       
        AllyMaxHealth = _ally._ally_health;
    }

    private void Update()
    {
        
        AllyCurrentHealth = _ally._ally_health;

       
        AllyHealthBar.fillAmount = AllyCurrentHealth / AllyMaxHealth;
    }
}
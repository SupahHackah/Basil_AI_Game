using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar_Script : MonoBehaviour
{
   
    private Image EnemyHealthBar;

   
    public float EnemyCurrentHealth;

   
    private float EnemyMaxHealth = 100f;

    Health_Script EnemyHP;

   
    private void Awake() 
    {   
        //Find
        EnemyHealthBar = GetComponent<Image>();
        EnemyHP = FindObjectOfType<Health_Script>();
    }

    private void Start()
    {
       
        EnemyMaxHealth = EnemyHP.EnemyHealth;
    }

    private void Update()
    {
        
        EnemyCurrentHealth = EnemyHP.EnemyHealth;

       
        EnemyHealthBar.fillAmount = EnemyCurrentHealth / EnemyMaxHealth;
    }
}

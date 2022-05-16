using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar_Script : MonoBehaviour
{
   
    private Image EnemyHealthBar;

   
    public float EnemyCurrentHealth;

   
    private float EnemyMaxHealth = 100f;

    Enemy_Ai_Manager _enemy;

   
    private void Awake() 
    {   
        //Find
        EnemyHealthBar = GetComponent<Image>();
        _enemy = FindObjectOfType<Enemy_Ai_Manager>();
    }

    private void Start()
    {
       
        EnemyMaxHealth = _enemy._enemy_health;
    }

    private void Update()
    {
        
        EnemyCurrentHealth = _enemy._enemy_health;

       
        EnemyHealthBar.fillAmount = EnemyCurrentHealth / EnemyMaxHealth;
    }
}

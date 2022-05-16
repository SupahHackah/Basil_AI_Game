using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrey : MonoBehaviour
{
    public int numberToSpawn =10;
    public GameObject aiSpawn;
    public float waitTime;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        while (numberToSpawn > 0)
        {
            Instantiate(aiSpawn, transform.position, transform.rotation);
            
            numberToSpawn--;
        }
    }   
    
}


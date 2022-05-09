using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AllySpawnTest : MonoBehaviour
{
    // Input fields
    private CharacterActionAsset characterActionAsset;


   public GameObject ally;
   //public GameObject player;
   private GameObject a;
   //public float spawnDist;
   public int allyNum = 5;
   public int x;

   private float spawnDist = 5;

   private void Awake()
   {
        // Assign Input Action Asset
        characterActionAsset = new CharacterActionAsset();
   }

    private void Update()
    {
        if (x < allyNum)
        {
            allySpawn();
            x++;
            print("value" + x);
        }
        

        /*
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            allyNum += 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            allyNum -= 1;
            x--;
        }
        */

    }

    private void allySpawn()
    {
        a = Instantiate(ally, new Vector3(transform.position.x + Random.Range(-spawnDist, spawnDist) , 5, transform.position.z + Random.Range(-spawnDist, spawnDist) ), Quaternion.identity) as GameObject;   
    }

    private void DestroyAlly()
    {
        Destroy(a);
    }
    
    private void FixedUpdate() 
    {
       // print("allyNum");
    }

    private void OnEnable()
    {
        characterActionAsset.Commands.AddAlly.started += DoAddAlly;
        characterActionAsset.Commands.RemoveAlly.started += DoRemoveAlly;
        characterActionAsset.Commands.Enable();
    }

    private void OnDisable()
    {
        characterActionAsset.Commands.AddAlly.started -= DoAddAlly;
        characterActionAsset.Commands.RemoveAlly.started -= DoRemoveAlly;
        characterActionAsset.Commands.Disable();
    }

    private void DoAddAlly(InputAction.CallbackContext obj)
    {
        allyNum += 1;
        Debug.Log("Ally Added");
    }

    private void DoRemoveAlly(InputAction.CallbackContext obj)
    {
        allyNum -= 1;
        x--;
        DestroyAlly();
        Debug.Log("Ally Removed");
    }
}

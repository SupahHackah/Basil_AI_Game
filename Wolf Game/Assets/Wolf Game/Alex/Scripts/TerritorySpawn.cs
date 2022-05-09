using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritorySpawn : MonoBehaviour
{
    public GameObject allyPrefab;
    public int allyNumber = 5;

    public void CreateEnemiesAroundPoint(int allyNumber, Vector3 point, float radius)
    {
 
        for (int i = 0; i < allyNumber; i++)
        {
 
            /* Distance around the circle */
            var radians = i * 2 * Mathf.PI / allyNumber ;
 
            /* Get the vector direction */
            var vertical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);
 
            var spawnDir = new Vector3(horizontal, 0, vertical);
 
            /* Get the spawn position */
            var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point
 
            /* Now spawn */
            var ally = Instantiate(allyPrefab, spawnPos, Quaternion.identity) as GameObject;
 
            /* Rotate the ally to face towards player */
            ally.transform.LookAt(point);
 
            /* Adjust height */
            ally.transform.Translate(new Vector3(0, ally.transform.localScale.y / 2, 0));
        }
    }
}

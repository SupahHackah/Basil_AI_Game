using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Health>() != null && collider.tag != "Player" )
        {
            Health otherhealth = collider.GetComponent<Health>();
            otherhealth.Damage(damage);
        }
    }
}
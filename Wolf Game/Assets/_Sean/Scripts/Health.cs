using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public int health = 9;
    public int MAX_HEALTH = 9;

    [Space]
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Update()
    {
        slider.transform.LookAt(Camera.main.transform);
        slider.maxValue = MAX_HEALTH;
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        Debug.Log("I am Dead!");
        //Destroy(gameObject);
    }
}


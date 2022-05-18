using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    Fox_Input input;

    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    void Awake()
    {
        input = new Fox_Input();
        input.CharacterControls.Attack.performed += Attack;
    }

        void Start()
    {
        attackArea = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }

        }
    }

    void Attack(InputAction.CallbackContext context)
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

    void OnEnable()
    {

        input.CharacterControls.Enable();
    }

    void OnDisable()
    {

        input.CharacterControls.Disable();
    }
}

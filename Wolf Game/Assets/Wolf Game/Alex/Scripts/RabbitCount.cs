using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RabbitCount : MonoBehaviour
{
    
    private TextMeshProUGUI textMesh;
    private GameObject rabbit;
    private string _text;

    [SerializeField] private int rabbitCount;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        //rabbit = FindObjectOfType<>();

    }


    void Start()
    {
        _text = "Rabbits Remaining " + rabbitCount;
        //rabbitCount = rabbit.
    }

    
    void Update()
    {
        textMesh.text = _text.ToString();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookAtCamera : MonoBehaviour
{
    private Camera _cam;
    public CinemachineVirtualCamera vcam;

    void Start()
    {
        //vcam = Camera.main;
    }

    void Update()
    {
        //transform.LookAt( 2 * transform.position - Camera.main.transform.position);
        transform.LookAt( 2 * transform.position - vcam.transform.position);
    }
}

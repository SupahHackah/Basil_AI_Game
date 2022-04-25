using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject cube;
    
    [ContextMenu("Scale Up")] // Adding this will create a right click entry for this component
    public void ScaleUp()
    {
        this.transform.localScale *= 2f;
    }

    [ContextMenu("Scale Down")] // u can use this for simple operations
    public void ScaleDown()
    {
        this.transform.localScale /= 2f;
    }

    [ContextMenu("Assign random color")] // For more complex stuff, look into proper editor scripting
    public void RandomColor()
    {
        //_sharedMat.color = Random.ColorHSV();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor(string color)
    {
        if (color.ToLower() == "red")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (color.ToLower() == "green")
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (color.ToLower() == "blue")
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}

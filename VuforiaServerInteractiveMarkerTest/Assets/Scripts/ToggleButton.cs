using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public bool state;
    public Material on, off;
    public float onHeight, offHeight;

    private void Start()
    {
       // Invoke("toggle", 3f);
       // Invoke("toggle", 6f);
    }

    public void toggle()
    {
        if (state)
        {
            GetComponent<MeshRenderer>().material = off;
            Vector3 pos = transform.localPosition;
            pos.y = offHeight;
            transform.localPosition = pos;
        }
        else
        {
            GetComponent<MeshRenderer>().material = on;
            Vector3 pos = transform.localPosition;
            pos.y = onHeight;
            transform.localPosition = pos;
        }
        state = !state;
    }
}

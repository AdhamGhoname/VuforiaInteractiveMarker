using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleIsland : MonoBehaviour
{

    public bool state;
    public float offHeight, onHeight;
    bool toggling = false;
    public float transitionTime;
    // Start is called before the first frame update
    void Start()
    {
        //toggle();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggling)
        {
            if (state)
            {
                Debug.Log(transform.localPosition.y);
                if (transform.localPosition.y < onHeight)
                {
                    transform.localPosition += new Vector3(0, onHeight - offHeight, 0) * Time.deltaTime / transitionTime;
                }
                else
                {
                    toggling = false;
                }
            }
            else
            {
                if (transform.localPosition.y > offHeight)
                {
                    transform.localPosition -= new Vector3(0, onHeight - offHeight, 0) * Time.deltaTime / transitionTime;
                }
                else
                {
                    toggling = false;
                }
            }
        }
    }

    public void toggle()
    {
        toggling = true;
        state = !state;
    }
}

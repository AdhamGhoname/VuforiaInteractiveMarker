using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumping : MonoBehaviour
{
    public float jumpLength, jumpTime;
    public ToggleButton[] buttons;
    int jumps = 0;
    bool levelEnded = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelEnded)
        {
            int count = 0;
            foreach (var i in buttons)
            {
                if (i.state)
                {
                    count++;
                }
            }
            if (count == buttons.Length)
            {
                GetComponent<Animator>().SetBool("Jump", true);
                levelEnded = true;
            }
        }
        if (jumps == 6)
        {
            CancelInvoke();
            GetComponent<Animator>().SetBool("Jump", false);
        }
    }

    public void jump()
    {
        transform.position += transform.forward * jumpLength;
        jumps++;
    }
}

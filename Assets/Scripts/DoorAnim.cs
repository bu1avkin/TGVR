using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{

    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        myAnimator.SetBool("IsClosed", true);
        
        
    }
}

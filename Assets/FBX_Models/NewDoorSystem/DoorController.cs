using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float animationDuration;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach(AnimationClip c in clips)
        {
            if (c.name == "DoorOpening")
            {
                animationDuration = c.length;
            }
        }
    }

    public void OpenDoor()
    {
        animator.SetTrigger("OpenDoor");
    }
}

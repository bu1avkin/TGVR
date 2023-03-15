using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject targetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject)
        {
            animator.SetTrigger("Sitting");
        }
    }
}


using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class Interactable : MonoBehaviour
{

    public UnityEvent unityEvent;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
               if ( collider.TryGetComponent(out NavMesh navmesh))
                {
                    navmesh.Interct(transform);
                }
            }
        }
    }
    public NavMesh GetInteractableObject()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NavMesh navmesh))
            {
                return navmesh;
            }
        }
        return null;
    }
    
        
    
}

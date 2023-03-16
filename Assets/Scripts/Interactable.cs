using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class Interactable : MonoBehaviour
{
    [SerializeField] XRController xrController;
    private float previousTriggerAxis;
    private float triggerThresholdValue;

    public UnityEvent OnTriggerPress;
    public UnityEvent OnTriggerRelease;

    private void Awake()
    {
        xrController = this.gameObject.GetComponent<XRController>();
        triggerThresholdValue = xrController.axisToPressThreshold;
    }

    private void Update()
    {

        float pressedTrigger;
        bool triggerAxis = xrController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out pressedTrigger);
        

        if ((pressedTrigger > triggerThresholdValue && previousTriggerAxis <= triggerThresholdValue) || Input.GetKeyDown(KeyCode.G))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NavMesh navmesh))
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

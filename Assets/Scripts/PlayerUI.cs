using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private Interactable playerInteract;


    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        containerGameObject.SetActive(true);
        containerGameObject.transform.LookAt(playerInteract.transform.position);
        containerGameObject.transform.rotation *= Quaternion.Euler(0, 180f, 0);

    }
    
    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}

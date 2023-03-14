using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InterObject : XRGrabInteractable
{
    public TextMeshPro displayText;
    public AudioSource audioSource;

    private bool isPlayerNearby = false;

    protected void OnSelectEnter(XRBaseInteractor interactor)
    {
        
        isPlayerNearby = true;
        displayText.text = "Поговорить";
    }

    protected void OnSelectExit(XRBaseInteractor interactor)
    {
        
        isPlayerNearby = false;
        displayText.text = "";
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.G))
        {
            audioSource.Play();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;

    [SerializeField] private float timeLeft = 20f;
    [SerializeField] private float timeBeforeStart = 20f;

    private float distance;
    private float distanceToExit;
    public Transform target;
    private Animator myAnimator;
   


    public AudioSource audioSource1;
    public AudioSource audioSource2;
    private bool AudioStart = false;
    private bool SecondAudio = false;
    private bool AudioStartSec = false;
    public float aidioTime = 10f;
    public float aidioTimetwo = 10f;
    public GameObject displayTextHide;
    public GameObject displayTextShow;
    bool EndSecond = false;
    public GameObject playerInteract;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
        displayTextShow.SetActive(false);




    }

    private void Update()

    {
        
       
        timeBeforeStart -= Time.deltaTime;
        if (timeBeforeStart < 0)
        {
            SetDestination();
            navMeshAgent.destination = movePositionTransform.position;

            distance = Vector3.Distance(target.position, transform.position);
            if (distance < 1)
            {
                /*navMeshAgent.enabled = false;*/
                myAnimator.SetTrigger("Sitting");
            }

            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                myAnimator.SetTrigger("Exit");
                navMeshAgent.destination = GameObject.Find("Cube").transform.position;
                

            }
            distanceToExit = Vector3.Distance(GameObject.Find("Cube").transform.position, transform.position);
            if (distanceToExit < 1)
            {
                
                myAnimator.SetBool("IsRunning", false);
                
            }

            if (AudioStart == true)
            {
                aidioTime -= Time.deltaTime;
                if (aidioTime< 0)
                {
                    SecondAudio = true;
                    audioSource1.Stop();
                    displayTextHide.SetActive(false);
                    displayTextShow.SetActive(true);
                    displayTextShow.transform.LookAt(playerInteract.transform.position);
                    displayTextShow.transform.rotation *= Quaternion.Euler(0, 180f, 0);
                    Debug.Log("Hello from Secod Audio");
                    
                }
            }
            if (AudioStartSec == true)
            {
                displayTextShow.SetActive(false);
                aidioTimetwo -= Time.deltaTime;
                if (aidioTimetwo < 0)
                {
                    EndSecond = true;
                }
            }
            
        }
        
        


    }

    private void SetDestination()
    {
        myAnimator.SetBool("IsRunning", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Door")
        {
            
            /*navMeshAgent.isStopped = true;*/
            other.GetComponent<DoorController>().OpenDoor();
        }
    }

    public void Interct(Transform intertransform)
    {
        if (AudioStart == false)
        {
            audioSource1.Play();
            AudioStart = true;

        }
        if (SecondAudio == true)
        {
            
            if (AudioStartSec == false)
            {
                audioSource2.Play();
                displayTextShow.SetActive(false);


                AudioStartSec = true;

                if (EndSecond == true)
                {
                    displayTextShow.SetActive(false);
                }
            }
            
        }

        Debug.Log("Interact");
    }
}

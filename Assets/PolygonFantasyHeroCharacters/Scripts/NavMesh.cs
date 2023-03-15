using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;

    [SerializeField] private float timeLeft = 20f;
    [SerializeField] private float timeBeforeStart = 20f;
    [SerializeField] private float moneyTime = 2f;

    private float distance;
    private float distanceToExit;
    public Transform target;
    private Animator myAnimator;

    [SerializeField] private GameObject containerGameObject;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
        containerGameObject.SetActive(false);

    }

    private void Update()

    {
        if (containerGameObject.activeInHierarchy == true)
        {
            moneyTime -= Time.deltaTime;
            if (moneyTime < 0)
            {
                containerGameObject.SetActive(false);
                moneyTime = 2f;
            }
        }
       
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
                Debug.Log("Im In");
                myAnimator.SetBool("IsRunning", false);
                
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
        containerGameObject.SetActive(true);
        
        Debug.Log("Interact");
    }
}

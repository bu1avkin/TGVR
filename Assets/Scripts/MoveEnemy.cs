using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Transform player;
    public Transform lookat;
    public float movementSpeed = 1;
    public float rotationSpeed = 1;



    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}

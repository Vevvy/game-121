using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool isCollected = true;
    private BoxCollider collider;
    public Transform playerTransform;

    public float distance;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, playerTransform.position);
            
        if(isCollected == true)
        {
            transform.position = playerTransform.position;
        }

        if(isCollected == true && Input.GetKeyDown("r"))
        {
            isCollected = false;
        }

        if(Input.GetKeyDown("space") && distance <= 1.25 && isCollected == false)
        {
            isCollected = true;
        }
    }
}

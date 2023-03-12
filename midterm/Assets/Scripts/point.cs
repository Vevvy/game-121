using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject pointController;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        pointController = GameObject.FindGameObjectWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerTransform.position, transform.position) < 1)
        {
            pointController.GetComponent<pointcontroller>().PointGet();
            Destroy(gameObject);
        }
    }
}

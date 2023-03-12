using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ouch : MonoBehaviour
{
    public Vector3 spawnPos;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnPos.x < 0)
        {
            transform.position += new Vector3(3, 0, 0.3f) * Time.deltaTime;

            if(transform.position.x > 15)
            {
                Destroy(gameObject);
            }
        }
        else if(spawnPos.x > 0)
        {
            transform.position += new Vector3(-3, 0, -0.3f) * Time.deltaTime;

            if (transform.position.x < -15)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<movement>().TakeDamage();
            Destroy(gameObject);
        }
    }
}

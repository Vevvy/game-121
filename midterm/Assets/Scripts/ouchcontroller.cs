using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ouchcontroller : MonoBehaviour
{
    public GameObject ouch;
    public float timer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if(timer <= 0)
        {
            spawnStuff();
            timer = 0.5f;
        }
    }

    public void spawnStuff()
    {
        Instantiate(ouch, new Vector3(-15, 0.5f, Random.Range(-10, 10)), new Quaternion());
        Instantiate(ouch, new Vector3(15, 0.5f, Random.Range(-10, 10)), new Quaternion());
    }
}

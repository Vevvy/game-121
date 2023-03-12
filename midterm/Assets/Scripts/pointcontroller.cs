using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointcontroller : MonoBehaviour
{
    public GameObject point;
    public int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(point, new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8)), new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        if(points == 5)
        {
            print("YOU WIN");
            Time.timeScale = 0;
        }
    }

    public void PointGet()
    {
        points += 1;
        Instantiate(point, new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8)), new Quaternion());
    }
}

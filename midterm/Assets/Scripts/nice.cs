using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nice : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            player.GetComponent<movement>().hp += 1;
            Destroy(gameObject);
        }
    }
}

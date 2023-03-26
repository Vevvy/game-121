using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    public Material red;
    public Material blue;
    public MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh.material = red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        if(mesh.material == red)
        {
            mesh.material = blue;
        }
        else if(mesh.material == blue)
        {
            mesh.material = red;
        }
    }
}

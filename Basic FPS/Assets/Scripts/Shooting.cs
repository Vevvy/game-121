using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera camera;
    public ParticleSystem flash;
    public ParticleSystem bullet;
    public float fireRate;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(fireRate > 0)
        {
            fireRate -= Time.deltaTime;
        }

        if(fireRate <= 0 && Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        flash.Play();
        bullet.Play();
        fireRate = 0.1f;
        
        Vector3 rcDir = -gun.transform.up;
        RaycastHit hit;
        Ray bulletRay = new Ray(camera.transform.position, rcDir);
        Physics.Raycast(bulletRay, out hit, 100);
        //Debug.DrawRay(camera.transform.position, Vector3.forward * 100, Color.green, 20f);

        if(hit.collider == true)
        {
            if(hit.collider.tag == "Enemy")
            {
                hit.transform.GetComponent<Enemy>().hp -= 1;
            }

            if (hit.collider.tag == "Block")
            {
                hit.transform.GetComponentInChildren<ParticleSystem>().Play();
            }

            if (hit.collider.tag == "ColorBlock")
            {
                hit.transform.GetComponent<ColorBlock>().mesh.material = hit.transform.GetComponent<ColorBlock>().blue;
            }
        }
    }
}

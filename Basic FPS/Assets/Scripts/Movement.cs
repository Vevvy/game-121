using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public Transform playerTransform;
    public CharacterController playerC;
    public GameObject camera;
    public Transform pivot;

    public float baseSpeed = 5;
    public float speed = 5;

    Vector3 velocity;

    public float mSpeedH = 2.0f;
    public float mSpeedV = 2.0f;

    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        playerC = player.GetComponent<CharacterController>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xDir + transform.forward * yDir;

        playerC.Move(move * speed * Time.deltaTime);

        playerC.Move(velocity * Time.deltaTime);

        // Mouse
        float mouseX = mSpeedH * Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY = mSpeedV * Input.GetAxis("Mouse Y") * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
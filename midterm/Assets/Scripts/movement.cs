using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private float Gravity = -9.81f;
   
    public Material poop;
    public Material red;

    public SkinnedMeshRenderer mesh;

    private Vector3 velocity;

    [SerializeField] private Camera camera;
    private CharacterController controller;

    private Animator animator;

    public int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y + 13, transform.position.z);

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * moveSpeed);

        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (move != Vector3.zero)
        {
            transform.forward = move;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void TakeDamage()
    {
        hp -= 1;

        mesh.material = red;

        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            yield return new WaitForSecondsRealtime(0.2f);

            mesh.material = poop;
        }

        if(hp <= 0)
        {
            print("YOU LOSE");
            Time.timeScale = 0;

            mesh.gameObject.SetActive(false);
        }
    }
}

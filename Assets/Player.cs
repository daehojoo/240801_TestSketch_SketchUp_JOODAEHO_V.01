using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{

    [SerializeField] private float movespeed = 6.0f;
    [SerializeField] private float rotspeed = 90f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CapsuleCollider capCollider;
    [SerializeField] private Transform tr;
    [SerializeField] public float jumpForce = 6f;
    [SerializeField] public bool isGround = true;
    [SerializeField] private float jumpCooldown = 1f; // 점프 쿨다운 시간 (초)
    private float lastJumpTime = 0f; // 마지막 점프 시간
    private Animator animator;
    private float groundCheckRadius = 0.4f;
    public LayerMask groundLayer;
    float h = 0, v = 0, r = 0;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        capCollider = GetComponent<CapsuleCollider>();
        tr = GetComponent<Transform>();
    }
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxisRaw("Mouse X");
        Vector3 moveDir = (h * Vector3.right) + (v * Vector3.forward);
        tr.Translate(moveDir.normalized * movespeed * Time.deltaTime, Space.Self);
        
        tr.Rotate(Vector3.up * r * Time.deltaTime * rotspeed);

        isGround = Physics.CheckSphere(tr.position + (Vector3.up * 0.2f), groundCheckRadius, groundLayer);


        animator.SetFloat("PosX", h);
        animator.SetFloat("PosY", v);
        

        if (Input.GetKeyDown(KeyCode.Space) && isGround && Time.time - lastJumpTime >= jumpCooldown&&h==0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            lastJumpTime = Time.time; // 마지막 점프 시간 갱신
            animator.SetBool("isJump", true);
        }
        if (isGround)
            animator.SetBool("isJump", false);
    }

}

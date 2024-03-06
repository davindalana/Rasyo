using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveDirection;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float dashSpeed =25f, dashDuration = 0.1f, dashCd = 1f;
    public bool isDash,canDash;
    void Start()
    {
        canDash = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (isDash)
        {
            return;
        }
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(mx, my).normalized;
        anim.SetFloat("MoveX", rb.velocity.x);
        anim.SetFloat("MoveY", rb.velocity.y);
        if (mx == 1 || mx == -1 || my == 1 || my == -1)
        {
            anim.SetFloat("LastMoveX", mx);
            anim.SetFloat("LastMoveY", my);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    void FixedUpdate()
    {
        if (isDash)
        {
            return;
        }
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDash = true;
        rb.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);

        isDash = false;
        yield return new WaitForSeconds(dashCd);
        canDash = true;
    }
}

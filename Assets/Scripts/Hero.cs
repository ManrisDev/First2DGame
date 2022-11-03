using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Hero : Entity
{
    [Header("Player Movement Settings")]
    [SerializeField][Range(0, 10f)] private float speed = 3f; //Movement speed
    [SerializeField][Range(0f, 15f)] private float jumpForce = 15f; //Jump power
    [SerializeField] private new Rigidbody2D rigidbody;

    [Header("Player Animation Settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;

    private bool isGrounded;

    private States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }
    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded) State = States.idle;

        //Попробовать по-другому реализовать
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        if (isGrounded) State = States.run;

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0f;
    }

    private void Jump()
    {
        //Попробовать по-другому реализовать прыжок
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.8f);
        isGrounded = collider.Length > 1;

        if (!isGrounded) State = States.jump;
    }
}
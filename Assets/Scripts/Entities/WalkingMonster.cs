using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class WalkingMonster : Entity
{
    [Header("Управление монстром")]
    [SerializeField][Range(0, 10f)] private float speed = 2f;

    [Header("Управление анимацией")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRender;

    private Vector3 direction;
    private bool isMove = true;

    private States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    private void Start()
    {
        lives = 7;
        direction = -transform.right;
    }

    private void Update()
    {
        if(isMove)
            Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Hero hero))
        {
            hero.Take_Damage(2);
            Take_Damage(1);
            isMove = !isMove;
            State = States.idle;
        }
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * direction.x * 0.7f, 0.1f);

        if (colliders.Length > 0)
        {
            direction *= -1f;
            spriteRender.flipX = !spriteRender.flipX;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        State = States.run;
    }
}


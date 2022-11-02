using UnityEngine;

public class WalkingMonster : Entity
{
    [Header("���������� ��������")]
    [SerializeField][Range(0, 10f)] private float speed = 2f;
    private SpriteRenderer sprite;

    [Header("���������� ���������")]
    private Animator animator;

    private Vector3 direction;
    private bool isMove = true;

    private States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        direction = -transform.right;
    }

    private void Update()
    {
        if(isMove)
            Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
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
            sprite.flipX = !sprite.flipX;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        State = States.run;
    }
}


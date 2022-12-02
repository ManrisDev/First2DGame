using UnityEngine;

public class Worm : Entity
{
    private void Start()
    {
        lives = 3;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Hero hero))
        {
            hero.Take_Damage(1);
            Take_Damage(1);
        }

        if (lives < 1)
            Die();
    }
}

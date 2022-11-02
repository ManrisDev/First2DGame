using UnityEngine;

public class Worm : Entity
{
    [SerializeField] private int lives = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;
            Debug.Log("У червяка " + lives + " жизней");
        }

        if (lives < 1)
            Die();
    }
}

using UnityEngine;

public abstract class Entity : MonoBehaviour
{

    protected int lives = 5; //Lives count

    public virtual void Take_Damage(int lost_lives)
    {
        lives -= lost_lives;
        Debug.Log(this.gameObject.name + " lives: " + lives);
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}

public enum States
{
    idle,
    run,
    jump
}

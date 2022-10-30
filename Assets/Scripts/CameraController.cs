using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 position;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<HeroMovement>().transform;
    }

    private void Update()
    {
        position = player.position;
        position.z = -10f;  //„тобы камера не приближалась к игроку

        //ѕлавное перемещение камеры за игроком
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
    }

}

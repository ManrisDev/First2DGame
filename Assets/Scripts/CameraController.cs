using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 position;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Hero>().transform;
    }

    private void Update()
    {
        position = player.position;
        position.z = -10f;  //����� ������ �� ������������ � ������

        //������� ����������� ������ �� �������
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
    }

}

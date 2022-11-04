using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField]
    [Range(0f, 10f)] private float camSpeed = 2f;
    [SerializeField]
    [Range(0f, 10f)] private float camHeight = 2.5f;

    private Vector3 position;

    private void Update()
    {
        position = player.position;
        position.z = -10f;  //����� ������ �� ������������ � ������
        position.y += camHeight;

        //������� ����������� ������ �� �������
        transform.position = Vector3.Lerp(transform.position, position, camSpeed * Time.deltaTime);
    }

}

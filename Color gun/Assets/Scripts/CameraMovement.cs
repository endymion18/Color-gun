using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        var target = player.transform.position;
        transform.position = new Vector3(target.x, target.y + 3f, transform.position.z);
    }
}
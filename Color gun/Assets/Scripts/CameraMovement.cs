using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMovement : MonoBehaviour
{
     public GameObject player;

    void Update()
    {
        var target = player.transform.position;
        transform.position = new Vector3(target.x, target.y + 3f, transform.position.z);
    }
}

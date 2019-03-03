using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float zOffset = 10f;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, player.transform.position.z - zOffset), Time.deltaTime * 100);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameObject player;
    private float gap = 15f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (gameObject.transform.position.z < player.transform.position.z - gap)
        {
            Destroy(gameObject);
        }
    }
}

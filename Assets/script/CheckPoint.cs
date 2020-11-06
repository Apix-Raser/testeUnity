using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameObject Spawn;

    private void Awake()
    {
        Spawn = GameObject.FindGameObjectWithTag("Respawn");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            Spawn.transform.position = gameObject.transform.position;
            Destroy(gameObject);

        }
    }
}

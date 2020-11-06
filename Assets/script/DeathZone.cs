using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform Spawn;
    private Animator FadeSystem;

    private void Awake()
    {
        Spawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();
        FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplaceSpawn(collision));
            
        }
    }

    private IEnumerator ReplaceSpawn(Collider2D collision)
    {
        FadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = Spawn.position;
    }
}

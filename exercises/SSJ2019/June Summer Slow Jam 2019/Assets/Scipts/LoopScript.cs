using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour
{
    public GameObject loopPoint;
    public AudioClip loopSound;
    public AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer.clip = loopSound;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = loopPoint.gameObject.transform.position;
        audioPlayer.Play();
        if (collision.CompareTag("Villager"))
        {
            collision.gameObject.GetComponent<VillagerScript>().speed *= 1.5f;
            collision.gameObject.GetComponent<VillagerScript>().health++;
            collision.gameObject.GetComponent<VillagerScript>().damage = 2;
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f, 1f);
        }
    }
}

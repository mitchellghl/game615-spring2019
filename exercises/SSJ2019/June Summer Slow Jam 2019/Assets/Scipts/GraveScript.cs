using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveScript : MonoBehaviour
{
    public float ritualTimer;
    public GameObject Skeleton;
    public Transform ritualLights;

    public AudioClip channelSound;
    public AudioSource audioPlayer;

    void Awake()
    {
        ritualLights = transform.Find("RitualLights");
        ritualLights.gameObject.SetActive(false);

        audioPlayer.clip = channelSound;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerController>().channeling == true)
            {
                ritualTimer += Time.deltaTime;
                ritualLights.gameObject.SetActive(true);
                audioPlayer.Play();
            }
        }
    }

    void Update()
    {
        if(ritualTimer > 0.5)
        {
            Instantiate(Skeleton, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

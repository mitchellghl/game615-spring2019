﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBouncerScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Skeleton"))
        {
            SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            sr.flipX = !sr.flipX;

            collision.gameObject.GetComponent<SkeletonScript>().facingRight = !collision.gameObject.GetComponent<SkeletonScript>().facingRight;

            collision.gameObject.GetComponent<SkeletonScript>().speed *= -1;
        }

        if (collision.CompareTag("Villager"))
        {
            SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            sr.flipX = !sr.flipX;

            collision.gameObject.GetComponent<VillagerScript>().facingRight = !collision.gameObject.GetComponent<VillagerScript>().facingRight;

            collision.gameObject.GetComponent<VillagerScript>().speed *= -1;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private float bounce = 14f;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ActivateJumpPad(collision));
        }
    }

    private IEnumerator ActivateJumpPad(Collision2D collision)
    {
        spriteRend.color = Color.red;
        anim.SetBool("activated", true);
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);

        // Wait for a short time to let the animation play
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("activated", false);
        spriteRend.color = Color.white;
    }
}

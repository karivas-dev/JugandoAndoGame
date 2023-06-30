using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    public GameObject gameMaster;

    private bool isDead = false; 

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM"); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !isDead) 
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true; 

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");

        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f); 

        Vector2 respawnPos = gameMaster.GetComponent<GameMaster>().lastCheckPointPos;
        transform.position = respawnPos;

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = Vector2.zero; 

        isDead = false;
    }
}




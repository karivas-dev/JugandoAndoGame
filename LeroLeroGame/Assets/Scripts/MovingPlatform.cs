using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class MovingPlatform : MonoBehaviour {

    public float speed;

    void FixedUpdate() {
        // Move the platform at a constant speed.
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        // If the player collides with the platform, set the player's parent to the platform.
        if (other.CompareTag("Player")) {
            other.transform.SetParent(this.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        // If the player leaves the platform, set the player's parent to null.
        if (other.CompareTag("Player")) {
            other.transform.SetParent(null);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private float speed = 10f; // vitesse initiale du joueur
    private bool isHit = false; // pour éviter la répétition de l'arrêt du joueur

    void FixedUpdate()
    {
        // déplacement du joueur avec la vitesse actuelle
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerController") && !isHit)
        {
            // arrêt du joueur pendant 0,5s après la collision avec le piège
            isHit = true;
            speed = 0f;
            Invoke("ResumeMovement", 1.5f);
        }
    }

    void ResumeMovement()
    {
        // reprise du déplacement du joueur après l'arrêt
        isHit = false;
        speed = 10f;
    }
}


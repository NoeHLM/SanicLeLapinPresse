using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if(player.checkpointIndex == index - 1)
    {
        player.checkpointIndex = index;
    }


}
    }
}


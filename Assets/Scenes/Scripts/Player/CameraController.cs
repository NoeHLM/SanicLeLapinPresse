using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    
    private Transform m_Target;

    [SerializeField] private BoxCollider firstzone;

    [SerializeField] private BoxCollider secondzone;
    private bool playerInFirstZone = false;
    private bool playerInSecondZone = false;
    private bool scoreIncremented = false;
    private bool score2Incremented = false;
    private int score = 0;
    private int score2 = 0;


    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private Vector3 m_Offset;
    [SerializeField]
    private Transform P1;
    [SerializeField]
    private Transform P2;

    // Update is called once per frame
    void Update()
    {
        if (score > score2)
        {
            m_Target= P1;
        }
        else if (score2 > score)
        {
            m_Target= P2;
        }
        else if (score==score2 ) 
        {
            if (score % 2 == 0)
            {
                if( P1.position.x >P2.position.x){
                    m_Target= P1;
                }
                else
                {
                    m_Target=P2;
                }
            }
            else {
                
            }
            
            
        }
        else
        {
            m_Target=P2;
        }
        Vector3 destination = Vector3.Lerp(transform.position, m_Target.position + m_Offset, m_Speed * Time.deltaTime);
        destination.x = Mathf.Clamp( destination.x,-23.6f,19.9f);
        destination.y = Mathf.Clamp( destination.y,-10f,6.5f);
        transform.position = destination;
        
       OnTriggerEnter2D();

}
 private void OnTriggerEnter2D()
    {
    
   if (!playerInFirstZone && score%2==0 && firstzone.bounds.Contains(GameObject.Find("Player").transform.position ))
    {
        // Le joueur est dans la première zone pour la première fois
        playerInFirstZone = true;
        score++;
        scoreIncremented = true;
        // Faites ce que vous devez faire quand le joueur entre dans la première zone
    }
    
    else if (playerInFirstZone && scoreIncremented && firstzone.bounds.Contains(GameObject.Find("Player").transform.position))
    {
        // Le joueur est revenu dans la première zone
        scoreIncremented = false;
    }

    Debug.Log(score);
    
}
}

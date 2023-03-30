using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    
    private Transform m_Target;
    [SerializeField] private BoxCollider2D testMort;

    [SerializeField] private BoxCollider firstzone;
    [SerializeField] private BoxCollider secondzone;
    private bool playerInFirstZone = false;
    private bool player2InFirstZone = false;
    private bool playerInSecondZone = false;
    private bool player2InSecondZone = false;
    private bool scoreIncrementedZ1 = false;
    private bool score2IncrementedZ1 = false;
    private bool scoreIncrementedZ2 = false;
    private bool score2IncrementedZ2 = false;
    private bool test = false;
    
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
                if( P1.position.x >P2.position.x){
                    m_Target= P2;
                }
                else
                {
                    m_Target=P1;
                }
            }
        }
            
       if (!testMort.GetComponent<BoxCollider2D>().OverlapPoint(GameObject.Find("Player").transform.position))
            {
                
            }
        if (!testMort.GetComponent<BoxCollider2D>().OverlapPoint(GameObject.Find("Player2").transform.position))
            {
                
            }
        
        Vector3 destination = Vector3.Lerp(transform.position, m_Target.position + m_Offset, m_Speed * Time.deltaTime);
        destination.x = Mathf.Clamp( destination.x,-30.6f,30.9f);
        destination.y = Mathf.Clamp( destination.y,-30f,30f);
        transform.position = destination;
        if(test==true)
           {
            test =false;
             GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize  - 0.2f;
             if(GetComponent<Camera>().orthographicSize < 2)
             {
                 GetComponent<Camera>().orthographicSize = 2; 
             }
           }
        OnTriggerEnter2D();
        

}
 private void OnTriggerEnter2D()
    {
    
   if (!playerInFirstZone &&  score%2==0 && firstzone.bounds.Contains(GameObject.Find("Player").transform.position ))
    {
        playerInFirstZone = true;
        
        scoreIncrementedZ1 = true;
    }
    
    else if (playerInFirstZone && scoreIncrementedZ1 && firstzone.bounds.Contains(GameObject.Find("Player").transform.position))
    {
        score+=1;
        scoreIncrementedZ1 = false;
        scoreIncrementedZ2 = true;  
    }

   if (!player2InFirstZone &&  score2%2==0 && firstzone.bounds.Contains(GameObject.Find("Player2").transform.position ))
    {
        player2InFirstZone = true;
        
        score2IncrementedZ1 = true;
    }
    
    else if (player2InFirstZone && score2IncrementedZ1 && firstzone.bounds.Contains(GameObject.Find("Player2").transform.position))
    {
        score2+=1;
        score2IncrementedZ1 = false;
        score2IncrementedZ2 = true;  
    }






    

    if (!playerInSecondZone &&  score%2==1 && secondzone.bounds.Contains(GameObject.Find("Player").transform.position ))
    {
        playerInSecondZone = true;
        
        scoreIncrementedZ2 = true;
    }
    
    else if (playerInSecondZone && scoreIncrementedZ2 && secondzone.bounds.Contains(GameObject.Find("Player").transform.position))
    {
        score+=1;
        scoreIncrementedZ2 = false;
        scoreIncrementedZ1 = true;
        test=true;
 
    }

    if (!player2InSecondZone &&  score2%2==1 && secondzone.bounds.Contains(GameObject.Find("Player2").transform.position ))
    {
        player2InSecondZone = true;
        
        score2IncrementedZ2 = true;
    }
    
    else if (player2InSecondZone && score2IncrementedZ2 && secondzone.bounds.Contains(GameObject.Find("Player2").transform.position))
    {
        score2+=1;
        score2IncrementedZ2 = false;
        score2IncrementedZ1 = true;
 
    }
    
}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private Vector3 m_Offset;

    [SerializeField]
    private float size;
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



    // Update is called once per frame
    void Update()
    {
        
        Vector3 destination = Vector3.Lerp(transform.position, m_Target.position + m_Offset, m_Speed * Time.deltaTime);
        destination.x = Mathf.Clamp( destination.x,-50.6f,50.9f);
        destination.y = Mathf.Clamp( destination.y,-50f,50f);
        transform.position = destination;

        

        if(Input.GetKey(KeyCode.Q))
         {
             GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize  + 1;
             if(GetComponent<Camera>().orthographicSize > 11)
             {
                 GetComponent<Camera>().orthographicSize = 11;
             }
         }
 
 
         if(Input.GetKey(KeyCode.E))
         {
             GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize  - 1;
             if(GetComponent<Camera>().orthographicSize < 2)
             {
                 GetComponent<Camera>().orthographicSize = 2; 
             }
         }
     }
     }
    

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

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = Vector3.Lerp(transform.position, m_Target.position + m_Offset, m_Speed * Time.deltaTime);
        destination.x = Mathf.Clamp( destination.x,-23.6f,19.9f);
        destination.y = Mathf.Clamp( destination.y,-10f,6.5f);
        transform.position = destination;
        Debug.Log(m_Target.position);
    }
}

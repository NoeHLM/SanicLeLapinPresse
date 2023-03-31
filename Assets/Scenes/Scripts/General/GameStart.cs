using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameStart : MonoBehaviour
{
     
    
    
    [SerializeField] TMP_Text countdownText;
    private float timeRemaining = 3f;

    // Start is called before the first frame update

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject player2;
   void Start()
    {
    GameObject player = GameObject.Find("Player");
    GameObject player2 = GameObject.Find("Player2");
    StartCoroutine(CountdownRoutine());
        
    }

    IEnumerator CountdownRoutine()
    {
        while (timeRemaining > -1)
        {
            countdownText.text = Mathf.CeilToInt(timeRemaining).ToString();
            yield return new WaitForSeconds(1f);
            timeRemaining--;
            Debug.Log(player);
        }
        countdownText.gameObject.SetActive(false);
        player.GetComponent<PlayerController>().enabled=true;
        player2.GetComponent<PlayerController>().enabled=true;
        
        
    }

void Update()
{
  
}



}
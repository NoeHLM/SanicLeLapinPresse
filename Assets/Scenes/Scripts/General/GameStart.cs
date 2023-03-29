using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameStart : MonoBehaviour
{
    float currentTime= 0f;
    float startingTime= 3f;
    
    
    [SerializeField] TMP_Text countdownText;
    private float timeRemaining = 3f;

    // Start is called before the first frame update
   void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        while (timeRemaining > -1)
        {
            countdownText.text = Mathf.CeilToInt(timeRemaining).ToString();
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }
        countdownText.gameObject.SetActive(false);
    }

void Update()
{
  
}



}
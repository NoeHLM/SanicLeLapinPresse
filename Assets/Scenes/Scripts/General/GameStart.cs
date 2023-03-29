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

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        
    }

    // Update is called once per frame
    bool goDisplayed = false;

void Update()
{
    currentTime -= 1 * Time.deltaTime;
    countdownText.text = currentTime.ToString("0");

     if (currentTime <= 0) {
        currentTime = 0;
        countdownText.text = "Go";
     }

    if (currentTime <= 0 && !goDisplayed)
    {
        currentTime = 0;
        countdownText.text = "Go";
        goDisplayed = true;
        Invoke("ResetCountdownText", 1f);
    }
}

void ResetCountdownText()
{
    countdownText.text = "";
}


}
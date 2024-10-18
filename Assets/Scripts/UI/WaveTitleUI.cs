using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveTitleUI : MonoBehaviour
{
    // ----- Implement Singleton

    public static WaveTitleUI Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // ----- UI Elements
    public Text waveTitleText;
    public Text displayInfosWave;

    // ----- Other methods

    private void Start()
    {
        
        displayInfosWave.text = "";
    }

    public void SetWaveTitle(int wave)
    {
        waveTitleText.text = "Vague: " + wave;
    }

    // Method to set wave info and hide after 'n' seconds
    public void SetWaveInfos(string infos, float displayDuration)
    {
        displayInfosWave.text = infos;
        // Start coroutine to hide the text after 'displayDuration' seconds
        StartCoroutine(HideWaveInfosAfterDelay(displayDuration));
    }

    // Coroutine to hide the wave info after a delay
    private IEnumerator HideWaveInfosAfterDelay(float delay)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delay);
        
        // Hide the text
        displayInfosWave.text = "";
    }
}
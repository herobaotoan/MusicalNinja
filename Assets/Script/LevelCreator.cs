using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public TextAsset txtFile;
    private float[] levelTime = new float[30];
    private float currentTime = 0f;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        ReadTxtFile();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // updateTimer();

        //Check approximate currentTime with time in LevelTime
        if (currentTime < (levelTime[currentIndex] + 0.05f) && (currentTime > levelTime[currentIndex] - 0.05f))
        {
            currentIndex++;
            // Debug.Log("HIT");
            //CREATE TILES
        }
    }

    public void ReadTxtFile()
    {
        char splitChar = ',';
        string[] output = txtFile.text.Split(splitChar);
        for (int i = 0; i < output.Length; i++)
        {
            //Turn string to float then store in an array
            levelTime[i] = float.Parse(output[i]);
        }
    }
    
    // void updateTimer()
    // {
    //     // int hours = Mathf.FloorToInt(currentTime / 3600f);
    //     // int minutes = Mathf.FloorToInt((currentTime - hours * 3600f) / 60f);
    //     // int seconds = Mathf.FloorToInt((currentTime - hours * 3600f) - (minutes * 60f));

    //     float minutes = Mathf.FloorToInt(currentTime / 60);
    //     float seconds = Mathf.FloorToInt(currentTime % 60);
    //     Debug.Log(string.Format("{0:00}:{1:00}", minutes, seconds));
    // }
}

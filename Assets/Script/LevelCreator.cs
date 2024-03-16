using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public TextAsset txtFile;
    private float[] levelTime = new float[30];
    private float currentTime = 0f;
    private float lastSpawnTime = 0f;
    public float timeBetweenSpawn;
    private int currentIndex = 0;

    [SerializeField] GameObject notePrefab;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject originalTile; //Used to get position
    private float positionX;
    private bool changePosition = false;
    // Start is called before the first frame update
    void Start()
    {
        ReadTxtFile();
        positionX = originalTile.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // updateTimer();

        //Check approximate currentTime with time in LevelTime
        if (currentIndex < levelTime.Length)
        {
            if (currentTime < (levelTime[currentIndex] + 0.05f) && (currentTime > levelTime[currentIndex] - 0.05f))
            {
                currentIndex++;
        
                //CREATE NOTE
                CreateNote();
                changePosition = !changePosition;
            }
            else {
                if ((currentTime - lastSpawnTime) > timeBetweenSpawn)
                {
                    lastSpawnTime = currentTime;
                    CreateTile();
                }
            }
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

    private void CreateNote()
    {
        if (changePosition)
        {
            Instantiate(notePrefab, new Vector3(positionX + 1f, 5.3f, 0.2f), Quaternion.identity);
        } else {
            Instantiate(notePrefab, new Vector3(positionX + 0f, 5.3f, 0.2f), Quaternion.identity);
        }
    }
    private void CreateTile()
    {
        if (changePosition)
        {
            Instantiate(tilePrefab, new Vector3(positionX + 1f, 5.3f, 0.2f), Quaternion.identity);
        } else {
            GameObject clone = (GameObject)Instantiate(tilePrefab, new Vector3(positionX + 0f, 5.3f, 0.2f), Quaternion.identity);
            //Flip vertically
            clone.transform.eulerAngles = new Vector3(clone.transform.eulerAngles.x, clone.transform.eulerAngles.y + 180f, clone.transform.eulerAngles.z);
        }
    }
    
    // void updateTimer()
    // {
    //     float minutes = Mathf.FloorToInt(currentTime / 60);
    //     float seconds = Mathf.FloorToInt(currentTime % 60);
    //     Debug.Log(string.Format("{0:00}:{1:00}", minutes, seconds));
    // }
}

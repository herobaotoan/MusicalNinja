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
    // private int currentIndex2 = 0;
    // public float timeBetweenSpawnAndPlayer;

    [SerializeField] GameObject notePrefab;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject blockPrefab;
    [SerializeField] GameObject originalTile; //Used to get position
    private float positionX;
    private bool changePosition = false;

    private AudioSource music;

    // private bool noteCreated = false;
    // public bool playerJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        ReadTxtFile();
        positionX = originalTile.transform.position.x;

        // CreateNote();
        // CreateTile();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        // updateTimer();
        //Delayed music start
        if (currentTime > 1.3f)
        {
            if (!music.isPlaying)
            {
                music.Play();
            }
        }
        if (currentIndex < levelTime.Length)
        {   
            //Create an object after a period of time
            if ((currentTime - lastSpawnTime) > timeBetweenSpawn)
            {
                //Check approximate currentTime with time in LevelTime
                if (currentTime < (levelTime[currentIndex] + 0.1f) && (currentTime > levelTime[currentIndex] - 0.1f))
                {
                    currentIndex++;
            
                    //CREATE NOTE and BLOCK
                    CreateNote();
                    CreateBlock();
                    changePosition = !changePosition;

                    lastSpawnTime = currentTime;
                }
                //If not NOTE time, CREATE TILE
                else {
                    lastSpawnTime = currentTime;
                    CreateTile();
                }
            }
        }
        
    // void Update()
    // {
    //     currentTime += Time.deltaTime;
    //     // updateTimer();

    //     if (currentTime > 1.3f)
    //     {
    //         if (!music.isPlaying)
    //         {
    //             music.Play();
    //         }
    //     }
    //     //Check approximate currentTime with time in LevelTime
    //     if (currentIndex < levelTime.Length)
    //     {
    //         if (currentTime < (levelTime[currentIndex] + 0.05f) && (currentTime > levelTime[currentIndex] - 0.05f))
    //         {
    //             currentIndex++;
        
    //             //CREATE NOTE
    //             CreateNote();
    //             changePosition = !changePosition;

    //             noteCreated = true;
    //         }
    //         else {
    //             //CREATE TILE
    //             if ((currentTime - lastSpawnTime) > timeBetweenSpawn)
    //             {
    //                 if (!noteCreated)
    //                 {
    //                     lastSpawnTime = currentTime;
    //                     CreateTile();
                        
    //                 } else {
    //                     noteCreated = false;
    //                 }
    //             }
    //         }
    //     }

        //SCORE CALCULATION (NOT WORKING)
        // if (currentTime < (levelTime[currentIndex2] + 0.05f + timeBetweenSpawnAndPlayer) && (currentTime > levelTime[currentIndex2] - 0.05f + timeBetweenSpawnAndPlayer))
        // {
        //     currentIndex2 ++;
        //     if(playerJumping)
        //     {
        //         Debug.Log("PASS");
        //     } else {
        //         Debug.Log("DEAD");
        //     }
        // } else {
        //     if(playerJumping)
        //     {
        //         Debug.Log("DEAD");
        //     } 
        // }
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
            Instantiate(notePrefab, new Vector3(positionX * -1f, 5.3f, 0.2f), Quaternion.identity);
        } else {
            Instantiate(notePrefab, new Vector3(positionX, 5.3f, 0.2f), Quaternion.identity);
        }
    }
    private void CreateBlock()
    {
        if (changePosition)
        {
            Instantiate(blockPrefab, new Vector3(positionX * -3.5f, 7f, 0.2f), Quaternion.identity);
        } else {
            GameObject clone = (GameObject)Instantiate(blockPrefab, new Vector3(positionX * 3.5f, 7f, 0.2f), Quaternion.identity);
            //Flip vertically
            clone.transform.eulerAngles = new Vector3(clone.transform.eulerAngles.x, clone.transform.eulerAngles.y + 180f, clone.transform.eulerAngles.z);
        }
    }
    private void CreateTile()
    {
        if (changePosition)
        {
            Instantiate(tilePrefab, new Vector3(positionX * -1f, 5.3f, 0.2f), Quaternion.identity);
        } else {
            GameObject clone = (GameObject)Instantiate(tilePrefab, new Vector3(positionX, 5.3f, 0.2f), Quaternion.identity);
            //Flip vertically
            clone.transform.eulerAngles = new Vector3(clone.transform.eulerAngles.x, clone.transform.eulerAngles.y + 180f, clone.transform.eulerAngles.z);
        }
    }

    // public void TooglePlayerJump()
    // {
    //     playerJumping = !playerJumping;
    // }
    
    // void updateTimer()
    // {
    //     float minutes = Mathf.FloorToInt(currentTime / 60);
    //     float seconds = Mathf.FloorToInt(currentTime % 60);
    //     Debug.Log(string.Format("{0:00}:{1:00}", minutes, seconds));
    // }
}

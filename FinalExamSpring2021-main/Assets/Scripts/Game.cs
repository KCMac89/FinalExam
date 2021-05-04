using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public int score = 0; 
    public int lives = 0;
  

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text livesText;
    [SerializeField]
    private GameObject menu;
   
    private bool isPaused = false;

    private void Awake()
    {
       // Pause();
    }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        menu.SetActive(false);
    }

    public void Pause()
    {
        menu.SetActive(true);
        //Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Unpause()
    {
        menu.SetActive(false);
       // Cursor.visible = false;
        Time.timeScale = 1;
        isPaused = false;
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();


        save.score = ScoreKeeper.newScore; // Scorekeeper.score
        save.lives = LivesTracker.lives; // LivesTracker.lives

        return save;
    }

    public void SaveGame()
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        // 3
       // score = 0;
       // lives = 0;
        scoreText.text = ScoreKeeper.newScore.ToString() ; // Scorekeeper.score
        livesText.text = LivesTracker.lives.ToString();

     
        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
       
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
       

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

           

         
            scoreText.text =  save.score.ToString();
            livesText.text =  save.lives.ToString();
            
            score = save.score;
            lives = save.lives;

            Debug.Log("Game Loaded");

            Unpause();
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }

    public void NewGame()
    {
        Unpause();
       SceneManager.LoadScene("1Intro");
    }
}

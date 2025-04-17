using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using JetBrains.Annotations;
using System.Threading;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    //public MapGenerator mapGenerator;

    public List<AudioSource> audioSources;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        //AudioSource[] audios = FindAnyObjectByType<AudioSource>();

        //foreach (AudioSource a in audios)
        //{
        //    a.Play();
        //}
    }

    public void ResumeGame()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}

//using Unity.VisualScripting;
//using UnityEngine;

//using UnityEngine.SceneManagement;



//public class PauseMenu : MonoBehaviour
//{
//    public GameObject pauseMenu;
//    public GameObject player;
//    [SerializeField]
//    public static bool isPaused;

//    void Start()
//    {
//        pauseMenu.SetActive(false);
//        //isPaused = false;
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))

//        {
//            if (isPaused)

//            {

//                ResumeGame();

//            }

//            else

//            {

//                PauseGame();

//            }

//        }

//    }



//    public void PauseGame()
//    {
//        Cursor.lockState = CursorLockMode.None;
//        Cursor.visible = true;


//        Debug.Log("paused");
//        //player.GetComponent<AB_Pistoil_Base>().
//        pauseMenu.SetActive(true);

//        Time.timeScale = 0f;

//        isPaused = true;
//    }



//    public void ResumeGame()

//    {
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;


//        Debug.Log("un-paused");
//        pauseMenu.SetActive(false);

//        Time.timeScale = 1f;

//        isPaused = false;

//    }



//    public void GoToMainMenu()

//    {

//        Time.timeScale = 1f;

//        SceneManager.LoadScene("OMcC_MainMenu");

//        isPaused = false;

//    }



//    public void QuitGame()

//    {

//        Application.Quit();



//#if UNITY_EDITOR

//        UnityEditor.EditorApplication.isPlaying = false;

//#endif

//    }

//}



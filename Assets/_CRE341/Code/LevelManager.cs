using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour

{
    public static LevelManager instance;

    //[SerializeField] private GameObject _loaderCanvas;

    //[SerializeField] private Image _progressBar;



    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;

    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }

    //}



    public void LoadScene(string sceneNmae)
    {
        SceneManager.LoadScene(sceneNmae);
    }
}
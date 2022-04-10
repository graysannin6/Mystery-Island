using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.UI;
using Cinemachine;

public class EndGame : MonoBehaviour
{
    private string sceneToReload = "LilasSceneS"; // Load this screen when starting game
    public PlayableDirector director;
    [SerializeField] private GameObject buttonreplay;
    [SerializeField] private GameObject buttonquit;
    [SerializeField] private Text gameCompleted;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject timeline;

    public void ReloadGame()
    {
        SceneManager.LoadScene(sceneToReload); //Load the game scene
    }

    public void Quit()
    {
        Application.Quit();
    }

    void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
            buttonreplay.SetActive(true);
            buttonquit.SetActive(true);
            gameCompleted.enabled = true;
            timeline.SetActive(false);
            canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    void OnDisable()
    {
        director.stopped -= OnPlayableDirectorStopped;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        buttonreplay.SetActive(false);
        buttonquit.SetActive(false);
        gameCompleted.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

//Reference
//https://docs.unity3d.com/2020.2/Documentation/ScriptReference/Playables.PlayableDirector-stopped.html //2021-03-17
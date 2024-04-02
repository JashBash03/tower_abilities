using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    void Start()
    {
        gameOverCanvas.SetActive(false);
        GameEvents.PlayerDied.AddListener(GameOver);
    }
    void GameOver()
    {
        gameOverCanvas.SetActive(true);
        StartCoroutine(DelayedReset());
    }

    IEnumerator DelayedReset()
    {
        yield return new WaitForSeconds(5f);
        Reset();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Reset();
        }
    }
    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level9Rocket : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float levelLoadTime = 1f;

    [SerializeField] private GameObject deadP;
    [SerializeField] private GameObject winP;

    private enum State { Alive, Dying, Transcending };

    State state;

    void Start()
    {
        state = State.Alive;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) return;

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                WinSequence();
                break;
            default:
                DeathSequence();
                break;
        }
    }

    private void WinSequence()
    {
        state = State.Transcending;
        winP.SetActive(true);
        Invoke("LoadNextScene", levelLoadTime);
        rb.Sleep();
        AudioManager.PlaySound("win", 1f);
    }

    private void DeathSequence()
    {
        state = State.Dying;
        Instantiate(deadP, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        AudioManager.PlaySound("explosion", 1f);
        Invoke("StartOver", levelLoadTime + 1f);
    }

    private void StartOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextScene()
    {
        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource auds;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float thrustSpeed = 100f;
    [SerializeField] private float levelLoadTime = 1f;

    [SerializeField] private ParticleSystem mainEngine;
    [SerializeField] private GameObject deadP;
    [SerializeField] private GameObject winP;

    private enum State {Alive, Dying, Transcending};

    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Alive;
        rb = gameObject.GetComponent<Rigidbody>();
        auds = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            Thrust();
            Rotate();
        }
    }

    private void LateUpdate()
    {
        if (state == State.Alive)
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
        }
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
        auds.Stop();
        mainEngine.Stop();
        Invoke("LoadNextScene", levelLoadTime);
        AudioManager.PlaySound("win", 1f);
    }

    private void DeathSequence()
    {
        state = State.Dying;
        Instantiate(deadP, gameObject.transform.position, new Quaternion(0,0,0,0));
        auds.Stop();
        AudioManager.PlaySound("explosion", levelLoadTime + 1);
        Invoke("StartOver", 2f);
    }

    private void StartOver()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.freezeRotation = true;
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        rb.freezeRotation = false;
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
            if (!auds.isPlaying)
            {
                mainEngine.Play();
                auds.Play();
            }
        }
        else
        {
            mainEngine.Stop();
            auds.Stop();
        }
    }
}

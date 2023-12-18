using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragonController : MonoBehaviour
{

    Rigidbody myBod;
    AudioSource myAudio;
    Animator myAnim;

    Text gameOverText;
    Text scoreText;

    public AudioClip crashClip;
    public AudioClip flapClip;
    public AudioClip pointClip;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody>();
        myBod.velocity = new Vector3(10, 0, 0);
        myAudio = GetComponent<AudioSource>();
        gameOverText = GameObject.Find("GameOver").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        myAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.timeScale <= 0)
        {
            if(Input.GetButtonDown("Jump"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }
        }

        if(Time.timeScale >= 1)
        {
            if (Input.GetButtonDown("Jump"))
            {
                myAnim.SetBool("Flap", true);
                myAudio.PlayOneShot(flapClip);
                myBod.velocity = new Vector3 (10, 15, 0);
            }

            if(!Input.GetButtonDown("Jump"))
            {
                myAnim.SetBool("Flap", false);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        if (otherGO.tag == "Surface")
        {
            Time.timeScale = 0;
            myAudio.PlayOneShot(crashClip);
            gameOverText.text = "Game Over" + "\n" + "Press Jump to Play Again";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGO = other.gameObject;
        myAudio.PlayOneShot(pointClip);
        score += 1;
        scoreText.text = "Score: " + score;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public AudioClip groundTouchSound;
    private AudioSource audioSource;

    private bool player1Wins = false;
    private int score1 = 0;
    private int score2 = 0;
    private UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getScore() {
        if (player1Wins) {
            return score1;
        } else {
            return score2;
        }
    }

    public int getPlayerWins() {
        if(player1Wins) {
            return 1;
        } else {
            return 2;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            Debug.Log("1 point");
            updatePlayerScore();
            audioSource.PlayOneShot(groundTouchSound, 1.0f);
        } else if (collision.gameObject.CompareTag("Player")) {
            player1Wins = !player1Wins;
        }
    }

    void updatePlayerScore() {
        if (player1Wins) {
            score1 += 1;
        } else {
            score2 += 1;
        }
        uIManager.updateScore(getPlayerWins(), getScore());
    }
}

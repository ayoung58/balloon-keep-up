using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTextPlayer1;
    public TextMeshProUGUI scoreTextPlayer2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int player, int score) {
        if (player == 1) {
            scoreTextPlayer1.text = "Player " + player + ": " + score;
        } else if (player == 2) {
            scoreTextPlayer2.text = "Player " + player + ": " + score;
        }
    }
}

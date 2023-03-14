using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayController : MonoBehaviour
{
    private Transform player;
    public TextMeshProUGUI scoreBoardText;
    public int score = 0;
    private static readonly string PLAYER_TAG = "Player";
    private void Start() {
        
        player = GameObject.FindWithTag( PLAYER_TAG ).transform;   
        StartCoroutine( CalculateScore() );
    }
    public void RestartButton()
    {
        // SceneManager.LoadScene( "SampleScene" );
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

    public void HomeButton()
    {
        SceneManager.LoadScene( "GameMenu" );
    }

    
    IEnumerator CalculateScore()
    {
        while( true )
        { 
             yield return new WaitForSeconds( 1 );
            if(player)
            {

             score++;    
            scoreBoardText.text = score.ToString();
            }
        }
    }
}

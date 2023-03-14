using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players;
    
    public static GameManager instance;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set{ _charIndex = value; }
    }

    private void Awake() {
        if( !instance )
        {
            instance = this;
            DontDestroyOnLoad( gameObject );
        }
        else
        {
            Destroy( gameObject );
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishLoading;    
    }

    private void onDisable()
    {
        SceneManager.sceneLoaded += OnLevelFinishLoading;    
    }

    void OnLevelFinishLoading( Scene scene, LoadSceneMode mode )
    {
        if( scene.name == "SampleScene" )
        {
            Instantiate( players[ CharIndex ] );
            
        }
    }
}

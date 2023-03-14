using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        int selectedGameCaracter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name );
        GameManager.instance.CharIndex = selectedGameCaracter;
        SceneManager.LoadScene("SampleScene");
    }


}

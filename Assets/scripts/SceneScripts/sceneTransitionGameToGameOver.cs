using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransitionGameToGameOver : MonoBehaviour

{
    public void sceneToMoveTo()
    {
        SceneManager.LoadScene(2);
    }
}


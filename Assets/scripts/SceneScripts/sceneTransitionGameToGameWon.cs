using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransitionGameToGameWon : MonoBehaviour
{
    public void sceneToMoveTo()
    {
        SceneManager.LoadScene(3);
    }
}

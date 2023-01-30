using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
   
   public void RestScores()
    {
        if(PlayerPrefs.GetInt("PlayerScore") != 0 || PlayerPrefs.GetInt("PaddleScore") != 0)
        {
            PlayerPrefs.SetInt("PlayerScore", 0);
            PlayerPrefs.SetInt("PaddleScore", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameObject.SetActive(false);
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false);
    }
}

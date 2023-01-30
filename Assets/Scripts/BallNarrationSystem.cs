using UnityEngine.UI;
using UnityEngine;

public class BallNarrationSystem : MonoBehaviour, IObserver
{
    [SerializeField] Subject _ballSubject;

    int playerScore;
    int playerPaddleScore;
    [SerializeField] Text PlayerScoreText;
    [SerializeField] Text PlayerPaddleScoreText;

    [SerializeField] AudioClip audioClip;
    AudioSource audio;

    [SerializeField] GameObject gameOverWindow;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        playerPaddleScore = PlayerPrefs.GetInt("PaddleScore", 0);
        PlayerPaddleScoreText.text = playerPaddleScore.ToString();

        playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        PlayerScoreText.text = playerScore.ToString();

    }

    public void OnNotify(BallAction ballAction)
    {
        if (ballAction == BallAction.CollisionWithSafeBoundaries)
        {
            audio.clip = audioClip;
            audio.Play();
        }
        else if (ballAction == BallAction.CollisionWithPlayerBoundaries)
        {
            playerPaddleScore++;
            PlayerPaddleScoreText.text = playerPaddleScore.ToString();
            PlayerPrefs.SetInt("PaddleScore", playerPaddleScore);
            _ballSubject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameOverWindow.SetActive(true);
        }
        else if (ballAction == BallAction.CollisionWithPlayerPaddleBoundaries)
        {
            playerScore++;
            PlayerScoreText.text = playerScore.ToString();
            PlayerPrefs.SetInt("PlayerScore", playerScore);
            _ballSubject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameOverWindow.SetActive(true);
        }

    }

    private void OnEnable()
    {
        _ballSubject.AddObservers(this);
    }

    private void OnDisable()
    {
        _ballSubject.RemoveObservers(this);
    }

}

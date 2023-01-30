using UnityEngine;

public class PlayerPaddleMovement : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float playerPaddleSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = ball.transform.position - transform.position;
        direction.x = 0;
        transform.Translate(direction * Time.deltaTime * Random.Range(1,playerPaddleSpeed));
    }
}

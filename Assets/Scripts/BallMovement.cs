using UnityEngine;

public class BallMovement : Subject
{
    [SerializeField] Vector2 startForce;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(startForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Left Boundary"))
        {
            NotifiyObservers(BallAction.CollisionWithPlayerPaddleBoundaries);
        }
        else if (collision.gameObject.CompareTag("Right Boundary"))
        {
            NotifiyObservers(BallAction.CollisionWithPlayerBoundaries);
        }
        else
        {
            NotifiyObservers(BallAction.CollisionWithSafeBoundaries);
        }
    }
}

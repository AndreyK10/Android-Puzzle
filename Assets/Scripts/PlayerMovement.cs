using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float force;
    private bool isMoving;

    private Vector2 fingerDown;
    private Vector2 fingerUp;
    [SerializeField] private bool detectSwipeOnlyAfterRelease = false;

    [SerializeField] private float SWIPE_THRESHOLD = 20f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    CheckSwipe();
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                CheckSwipe();
            }
        }

        if (rb.velocity == Vector2.zero)
        {
            isMoving = false;
        }

    }
    private void CheckSwipe()
    {
        if (VerticalMove() > SWIPE_THRESHOLD && VerticalMove() > HorizontalValMove())
        {
            if (fingerDown.y - fingerUp.y > 0)
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        else if (HorizontalValMove() > SWIPE_THRESHOLD && HorizontalValMove() > VerticalMove())
        {
            if (fingerDown.x - fingerUp.x > 0)
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }
    }

    private float VerticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    private float HorizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    private void OnSwipeUp()
    {
        Move(Vector2.up);
    }

    private void OnSwipeDown()
    {
        Move(Vector2.down);
    }

    private void OnSwipeLeft()
    {
        Move(Vector2.left);
    }

    private void OnSwipeRight()
    {
        Move(Vector2.right);
    }

    private void Move(Vector2 v)
    {
        if (!isMoving)
        {
            rb.AddForce(v * force, ForceMode2D.Impulse);
            isMoving = true;
        }
    }

}

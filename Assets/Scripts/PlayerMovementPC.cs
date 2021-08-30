using UnityEngine;

public class PlayerMovementPC : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float force;
    [SerializeField] private bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W)) Move(Vector2.up);
            else if (Input.GetKeyDown(KeyCode.S)) Move(Vector2.down);
            else if (Input.GetKeyDown(KeyCode.A)) Move(Vector2.left);
            else if (Input.GetKeyDown(KeyCode.D)) Move(Vector2.right);


        }
        if (rb.velocity == Vector2.zero)
        {
            isMoving = false;
        }
        //if (_allSquares.Count == 0);


    }

    private void Move(Vector2 v)
    {
        rb.AddForce(v * force, ForceMode2D.Impulse);
        isMoving = true;
    }
}

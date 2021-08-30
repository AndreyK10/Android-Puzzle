using UnityEngine;

public class PlayerController : MonoBehaviour
{  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SpriteRenderer>())
        {
            collision.GetComponent<SpriteRenderer>().color = LevelController.instance.color;
            Instantiate(LevelController.instance.squareLight, collision.transform.position, Quaternion.identity, collision.transform);
            collision.GetComponent<BoxCollider2D>().enabled = false;
            LevelController.instance.RemoveFromList();
        }
    }
}

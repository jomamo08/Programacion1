using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public float fallSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManagerScript>().AddScore();
        }
        Destroy(gameObject);
    }
}
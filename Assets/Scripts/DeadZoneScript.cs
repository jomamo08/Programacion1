using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    public GameObject gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle"))
        {
            gameManager.GetComponent<GameManagerScript>().AddScore();
            Destroy(other.gameObject);
        }
    }
}
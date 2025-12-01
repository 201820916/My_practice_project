using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Debug.Log("GAME OVER!!!!");

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
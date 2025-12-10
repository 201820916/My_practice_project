using UnityEngine;

public class Planet : MonoBehaviour
{
    public Gamemanager manager;

    float t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (transform.position.y > 4.1f)
        {
            t += Time.deltaTime;

            if (t > 3)
            {
                manager.GameOver();
            }
        }

        else
        {
            t = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.tag == collision.gameObject.tag)
        {
            if(this.gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
            {
                int currentLevel = int.Parse(this.gameObject.tag);
                int nextLevel = currentLevel + 1;
                manager.AddScore(nextLevel);


                GameObject clone = Instantiate(manager.planets[int.Parse(this.gameObject.tag)]);
                clone.transform.position = transform.position;
                clone.GetComponent<Rigidbody2D>().gravityScale = 1;
                clone.GetComponent<Collider2D>().enabled = true;
                clone.GetComponent<Planet>().manager = manager;
            }

            Destroy(this.gameObject);
        }
    }
}


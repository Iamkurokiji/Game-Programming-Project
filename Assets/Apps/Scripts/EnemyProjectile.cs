using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float moveSpeed;
    private float lowerYBound;
    // Start is called before the first frame update
    void Start()
    {
        float zDist = transform.position.z - Camera.main.transform.position.z;

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDist));
        lowerYBound = bottomLeft.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        // Destroy if it goes past the top screen boundary
        if (transform.position.y <= lowerYBound)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
          
        }
    }
}


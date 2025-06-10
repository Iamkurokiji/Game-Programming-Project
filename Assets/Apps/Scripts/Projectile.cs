using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;

    private float upperYBound;

    // Start is called before the first frame update
    void Start()
    {
        float zDist = transform.position.z - Camera.main.transform.position.z;

        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, zDist));
        upperYBound = topRight.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        // Destroy if it goes past the top screen boundary
        if(transform.position.y >= upperYBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

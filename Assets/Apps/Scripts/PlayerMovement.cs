using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float hInput;
    public float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        // Calculate boundaries based on camera and player sprite size
        Camera cam = Camera.main;
        float halfPlayerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;

        Vector3 LeftBound = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - cam.transform.position.z));
        Vector3 RightBound = cam.ViewportToWorldPoint(new Vector3(1, 0, transform.position.z - cam.transform.position.z));

        minX = LeftBound.x + halfPlayerWidth;
        maxX = RightBound.x - halfPlayerWidth;

        Debug.Log($"Left Bound: {minX} | Right Bound: {maxX} | Half Width: {halfPlayerWidth}");
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        Vector3 position = transform.position;
        position.x += hInput * moveSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, minX, maxX);

        transform.position = position;
        
        
        //Redundant
        //transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);
    }
}

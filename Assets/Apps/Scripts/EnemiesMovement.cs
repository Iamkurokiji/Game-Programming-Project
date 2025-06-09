using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    public float moveSpeed;
    public float boundaryOffset = 0.5f;
    public float moveDownAmount = 0.5f;
    public float boundaryCooldown = 0.2f;
    
    private float minX, maxX;
    private bool isInCooldown = false;
    private Vector2 moveDirection = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        float zDist = transform.position.z - cam.transform.position.z;

        Vector3 LeftBound = cam.ViewportToWorldPoint(new Vector3(0, 0, zDist));
        Vector3 RightBound = cam.ViewportToWorldPoint(new Vector3(1, 0, zDist));

        minX = LeftBound.x + boundaryOffset;
        maxX = RightBound.x - boundaryOffset;

        Debug.Log($"Left Bound: {minX} | Right Bound: {maxX} | ZDist: {zDist}");
    }

    // Update is called once per frame
    void Update()
    {
       float step = moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection * step);

        if (!isInCooldown)
        {
            foreach (Transform enemy in transform)
            {
                float nextX = enemy.position.x + moveDirection.x * step;
                
                if (nextX <= minX || nextX >= maxX)
                {
                    StartCoroutine(MoveDownAndReverse());
                    break;
                }
            }
        }
    }

    IEnumerator MoveDownAndReverse()
    {
       isInCooldown = true;
       moveDirection *= -1f; // Reverse Direction
       transform.position += Vector3.down * moveDownAmount;
       yield return new WaitForSeconds(boundaryCooldown);
       isInCooldown = false;

     }
}

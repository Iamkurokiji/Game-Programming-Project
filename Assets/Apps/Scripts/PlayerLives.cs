using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] LivesUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Alien")
        {
            Destroy(collision.collider .gameObject);
            lives -= 1;
            for (int i = 0; i < LivesUI.Length; i++)
            {
                if (i < lives)
                {
                    LivesUI[i].enabled = true;
                }
                else
                {
                    LivesUI[i].enabled = false;
                }
            }
            if (lives <= 0)
                {
                    Destroy(gameObject);
                }
        }
    }
}

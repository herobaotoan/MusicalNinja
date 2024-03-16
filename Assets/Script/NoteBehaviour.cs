using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public GameObject player;
    private GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        score = GameObject.Find("Score");
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    // SCORE CALCULATION (OLD)
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            if (player.GetComponent<CharacterMovement>().isJumping)
            {
                Debug.Log("OK");
                score.GetComponent<ScoreAppear>().Appear();
            } else {
                Debug.Log("DEAD");
            }
        }
    }
}

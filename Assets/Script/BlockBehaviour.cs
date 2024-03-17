using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    [SerializeField] GameObject[] pieces;
    public float breakForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    public void Break()
    {
        foreach (GameObject piece in pieces)
        {
            piece.transform.SetParent(null);
            //Add components
            Rigidbody2D rb = piece.AddComponent<Rigidbody2D>();
            Collider2D col = piece.AddComponent<BoxCollider2D>();
            col.isTrigger = false;
            //Apply random force
            rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * breakForce);
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {   
        if (coll.gameObject.CompareTag("Knife"))
        {
            Break();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    // [SerializeField] GameObject tilePrefab;
    // public float thickness = 0.3f;
    // public LayerMask groundLayer;
    // public bool stopCreate = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // if (!stopCreate)
        // {
            // StartCoroutine("DelayedCreateTile");
        // }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    
    //CREATE TILE (OLD WAY)

    // IEnumerator DelayedCreateTile()
    // {
    //     Vector2 pos = new Vector2(rb.position.x, rb.position.y + 0.7f);
    //     yield return new WaitForSeconds(0.17f);
    //     RaycastHit2D hit = Physics2D.CircleCast(pos, thickness, Vector2.up, 0f, groundLayer);
    //     // Debug.Log(hit.collider);
    //     if (hit.collider == null)
    //     {
    //         Instantiate(tilePrefab, new Vector3(rb.position.x, rb.position.y + 1.0f, 0.5f), Quaternion.identity);
    //     } else {
    //         GameObject clone = (GameObject)Instantiate(tilePrefab, new Vector3(rb.position.x, rb.position.y + 1.0f, 0.5f), Quaternion.identity);
    //         clone.GetComponent<TileBehaviour>().stopCreate = true;
    //         if (rb.position.x > 0f)
    //         {   
    //             yield return new WaitForSeconds(0.22f);
    //             Instantiate(tilePrefab, new Vector3(rb.position.x - 1f, rb.position.y + 2.0f, 0.5f), Quaternion.identity);
    //         } else {
    //             yield return new WaitForSeconds(0.22f);
    //             GameObject clone2 = (GameObject)Instantiate(tilePrefab, new Vector3(rb.position.x + 1f, rb.position.y + 2.0f, 0.5f), Quaternion.identity);
    //             clone2.transform.eulerAngles = new Vector3(clone.transform.eulerAngles.x, clone.transform.eulerAngles.y + 180f, clone.transform.eulerAngles.z);
    //         }
    //     }
        
    // }
}

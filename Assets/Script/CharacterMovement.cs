using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float direction = 1f;
    public bool isJumping = false;
    public float jumpTime = 0.1f;
    public LayerMask groundLayer;
    [SerializeField] GameObject game;

    public void Jump()
    {
        // if (isLeft)
        // {
        //     transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        //     isLeft = false;
        // } else {
        //     transform.position = new Vector3(transform.position.x + -1f, transform.position.y, transform.position.z);
        //     isLeft = true;
        // }
        if (!isJumping) StartCoroutine("SmoothJump");
    }

    void Update()
    {   
        //If not jumping: Check is standing on Tile
        if (!isJumping)
        {
            // StartCoroutine("DelayedCheckGround");
        }
    }

    //Use to checkground after jumping
    private IEnumerator DelayedCheckGround()
    {
        yield return new WaitForSeconds(0.5f);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.3f, Vector2.up, 0f, groundLayer);
        if (hit.collider == null)
        {
            Debug.Log("DEAD");
        }
    }
    
    private IEnumerator SmoothJump()
    {
        isJumping = true;
        // game.GetComponent<LevelCreator>().TooglePlayerJump();
        // float time = 0.2f; //Jumping time
        Vector3 start = transform.position;
        Vector3 destination = new Vector3(transform.position.x + direction, transform.position.y, transform.position.z);

        float elapsedTime = 0;
        
        while (elapsedTime < jumpTime)
        {
            transform.position = Vector3.Lerp(start, destination, (elapsedTime / jumpTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //Change Direction
        if (direction < 1f)
        {
            direction = 1f;
        } else {
            direction = -1f;
        }
        isJumping = false;
        
        //Checkground after jumping
        yield return StartCoroutine("DelayedCheckGround");
        // game.GetComponent<LevelCreator>().TooglePlayerJump();
    }

    // void OnTriggerExit2D(Collider2D coll)
    // {
    //     if (coll.gameObject.CompareTag("Tile"))
    //     {
    //         Debug.Log("DEAD");
    //     }
    // }
}

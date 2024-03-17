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
    [SerializeField] GameObject knifePrefab;
    public float knifeSpeed = 5f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

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
        ThrowKnife(direction);
        isJumping = true;
        // game.GetComponent<LevelCreator>().TooglePlayerJump();
        // float time = 0.2f; //Jumping time
        Vector3 start = transform.position;
        Vector3 destination = new Vector3(-transform.position.x, transform.position.y, transform.position.z);

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
            //Make sure player stand on the right position
            transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
            direction = 1f;
        } else {
            //Make sure player stand on the right position
            transform.position = new Vector3(startPosition.x * -direction, startPosition.y, startPosition.z);
            direction = -1f;
        }
        isJumping = false;

        
        //Checkground after jumping
        yield return StartCoroutine("DelayedCheckGround");
        // game.GetComponent<LevelCreator>().TooglePlayerJump();
    }

    private void ThrowKnife(float direction)
    {
        GameObject clone = (GameObject)Instantiate(knifePrefab, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
        //Rotate the knife
        clone.transform.eulerAngles = new Vector3(clone.transform.eulerAngles.x, clone.transform.eulerAngles.y, 80f * direction);
        //Add velocity to the knife
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2(knifeSpeed * -direction, 2f);

    }

    // void OnTriggerExit2D(Collider2D coll)
    // {
    //     if (coll.gameObject.CompareTag("Tile"))
    //     {
    //         Debug.Log("DEAD");
    //     }
    // }
}

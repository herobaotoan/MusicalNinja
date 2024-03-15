using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float direction = 1f;
    private bool isJumping = false;

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

    
    private IEnumerator SmoothJump()
    {
        isJumping = true;
        float time = 0.3f; //Jumping time
        Vector3 start = transform.position;
        Vector3 destination = new Vector3(transform.position.x + direction, transform.position.y, transform.position.z);

        float elapsedTime = 0;
        
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(start, destination, (elapsedTime / time));
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
    }
}

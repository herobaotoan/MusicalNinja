using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAppear : MonoBehaviour
{
    void Start()
    {
        transform.localScale = new Vector3(0f, 0f, 0f);
    }

    public void Appear()
    {
        StartCoroutine("AppearAndZoom");
    }

    IEnumerator AppearAndZoom()
    {
        float elapsedTime = 0;
        Vector3 targetScale = new Vector3(1f,1f,1f);
        transform.localScale = new Vector3(0f, 0f, 0f);
        
        float time = 0.5f; 
        
        while (elapsedTime < time)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, (elapsedTime / time));
        
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        // Destroy(gameObject);
        transform.localScale = new Vector3(0f, 0f, 0f);
    }
}

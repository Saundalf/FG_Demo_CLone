using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic2 : MonoBehaviour
{
    public GameObject sphere;
    public float delayTimer = 5f;
    [SerializeField] private Vector2 randomTimeRange;
    bool isUp = false;

    private void Start()
    {
        //var clamped = Mathf.Clamp(delayTimer, 0, 1);
        StartCoroutine(DelayCor(Random.Range(randomTimeRange.x,randomTimeRange.y)));
    }

    private IEnumerator DelayCor(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        popUp(isUp);
        StartCoroutine(DelayCor(Random.Range(randomTimeRange.x, randomTimeRange.y)));
    }

    void popUp(bool up)
    {
        if (up)
        {
            isUp = false;
            transform.Translate(0, -1.5f, 0);
        }
        else if (!up)
        {
            transform.Translate(0, 1.5f, 0);
            isUp = true;
        }
    }
}
//DelayCor
//waits for a second
//popUp
//DelayCor
//waitfor a second
//popup
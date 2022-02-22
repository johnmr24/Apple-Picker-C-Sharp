using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 20f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;
    public Text score;

    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void Update()
    {
        int number;

        if (int.TryParse(score.text, out number) == true)
        {
            if (number >= 1000 && number < 2000)
            {
                if (secondsBetweenAppleDrops > 0.8f)
                    secondsBetweenAppleDrops *= 0.8f;
                if (Mathf.Abs(speed) < 20f)
                    speed *= 1.001f;
            }
            else if (number >= 2000 && number < 3000)
            {
                if (secondsBetweenAppleDrops > 0.6f)
                    secondsBetweenAppleDrops *= 0.8f;
                if (Mathf.Abs(speed) < 40f)
                    speed *= 1.001f;
            }
            else if (number > 3000)
            {
                if (secondsBetweenAppleDrops > 0.3f)
                    secondsBetweenAppleDrops *= 0.8f;
                if (Mathf.Abs(speed) < 75f)
                    speed *= 1.001f;
            }
        }

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //right border
        if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        //left border
        else if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
}

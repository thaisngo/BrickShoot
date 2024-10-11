using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_Move : MonoBehaviour
{
    private RectTransform brick_alone;
    private Vector2 newPos;
    public float vanTocBrickBanLen = 150f;
    public bool canMove = true;
    public int idCol;

    void Start()
    {
        brick_alone = GetComponent<RectTransform>();
        newPos = new Vector2(brick_alone.anchoredPosition.x, 950f);
    }

    void FixedUpdate()
    {
        MoveBrick();
    }

    private void MoveBrick()
    {
        if (canMove)
        {
            brick_alone.localPosition = Vector2.MoveTowards(brick_alone.localPosition, newPos, vanTocBrickBanLen);
        }
    }
}

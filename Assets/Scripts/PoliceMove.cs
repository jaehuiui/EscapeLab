using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int speed;

    public int horizontalMove = 1;
    public int verticalMove = 1;

    public int direction;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Invoke("move", 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rigid.velocity = new Vector2(horizontalMove, verticalMove) * speed;

        Vector2 horizontalVec = new Vector2(rigid.position.x + horizontalMove, rigid.position.y);
        Vector2 verticalVec = new Vector2(rigid.position.x, rigid.position.y + verticalMove);

        RaycastHit2D rayHitLeft = Physics2D.Raycast(horizontalVec, Vector2.left, 1, LayerMask.GetMask("Border"));
        RaycastHit2D rayHitRight = Physics2D.Raycast(horizontalVec, Vector2.right, 1, LayerMask.GetMask("Border"));
        RaycastHit2D rayHitUp = Physics2D.Raycast(verticalVec, Vector2.up, 1, LayerMask.GetMask("Border"));
        RaycastHit2D rayHitDown = Physics2D.Raycast(verticalVec, Vector2.down, 1, LayerMask.GetMask("Border"));

        if (rayHitLeft.collider != null)
        {
            horizontalMove *= -1;
            CancelInvoke();
            Invoke("move", 2);
        }
        if (rayHitRight.collider != null)
        {
            horizontalMove *= -1;
            CancelInvoke();
            Invoke("move", 2);
        }
        if (rayHitUp.collider != null)
        {
            verticalMove *= -1;
            CancelInvoke();
            Invoke("move", 2);
        }
        if (rayHitDown.collider != null)
        {
            verticalMove *= -1;
            CancelInvoke();
            Invoke("move", 2);
        }
    }
    void move()
    {

        horizontalMove = Random.Range(-1, 2);
        verticalMove = Random.Range(-1, 2);

        float nextDecideTime = Random.Range(1f, 4f);

        Invoke("move", nextDecideTime);

    }
}

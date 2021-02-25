using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceTracker : MonoBehaviour
{
    Rigidbody2D rigid;
    Transform target;
    public Vector3 targetDirection;

    public int speed;

    public int horizontalMove = 1;
    public int verticalMove = 1;

    public int direction;

    public float chaseSpeed;

    public bool isChasing = false;

    // Start is called before the first frame update

    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Awake()
    {
        Invoke("move", 1);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ChaseTarget();
    }

    void ChaseTarget()
    {
        targetDirection = (target.position - transform.position).normalized;

        chaseSpeed = 0.05f;

        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= 4.2f)
        {
            this.transform.position = new Vector2(transform.position.x + (targetDirection.x * chaseSpeed),
                                                   transform.position.y + (targetDirection.y * chaseSpeed));
            isChasing = true;
        }
        else {
            isChasing = false;
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
                Invoke("move", 1);
            }
            if (rayHitRight.collider != null)
            {
                horizontalMove *= -1;
                CancelInvoke();
                Invoke("move", 1);
            }
            if (rayHitUp.collider != null)
            {
                verticalMove *= -1;
                CancelInvoke();
                Invoke("move", 1);
            }
            if (rayHitDown.collider != null)
            {
                verticalMove *= -1;
                CancelInvoke();
                Invoke("move", 1);
            }
        }
    }

    void move()
    {

        horizontalMove = Random.Range(-1, 2);
        verticalMove = Random.Range(-1, 2);

        float nextDecideTime = Random.Range(1f, 2.5f);

        Invoke("move", nextDecideTime);

    }
}

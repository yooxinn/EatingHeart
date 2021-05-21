using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public int creatureType;
    public int score;
    public float movePower = 1f;

    Rigidbody2D rigid;
    public int nextMove;

    Vector3 movement;
    bool isTracing = false;
    bool isDie = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        

        Invoke("Think", 5);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, LayerMask.GetMask("Block"));
        if (rayHit.collider == null)
        {
            nextMove = nextMove * -1;
            CancelInvoke();
            Think();
        }
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);

        float nextThinkTime = Random.Range(1f, 4f);
        Invoke("Think", nextThinkTime);
    }
 
}

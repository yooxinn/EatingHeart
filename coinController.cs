using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {

        Score.coinAmount += 1;
        Destroy(gameObject);
    }
}

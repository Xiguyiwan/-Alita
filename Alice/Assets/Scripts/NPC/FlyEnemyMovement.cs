using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyMovement : MonoBehaviour
{
    public  GameObject player;//

    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // iTween.MoveUpdate(this.gameObject, iTween.Hash("position", player.transform.position, "speed", speed));
        //this.transform.position = player.transform.position;
    }

    void moveToPlayer()
    {
        //iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
        iTween.MoveTo(this.gameObject, iTween.Hash("position", player.transform.position, "speed", speed));
    }
}

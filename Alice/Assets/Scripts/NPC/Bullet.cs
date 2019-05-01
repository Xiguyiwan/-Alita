using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 10;
    public int distance = 50;
    public int damagePerShot = 20;                  // Урона за выстрел
    // Start is called before the first frame update
    Vector3 startPoint;
    float currentDistance;

    int scoreForDestroyIt= 1;

    public bool wasDestoed = false;
    public GameObject player;
    public PlayerHealthHelper _playerHealth;
    void Awake()
    {
        startPoint = this.transform.position;
        player = GameObject.Find("Player");
        _playerHealth = player.GetComponent<PlayerHealthHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!wasDestoed)
        {
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }else
        {
            this.transform.Translate(Vector3.back * 20 * Time.deltaTime);
        }
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        currentDistance = (Vector3.Distance(startPoint, this.transform.position));
        if(currentDistance > 20)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        //_playerHealth.GetDamage(damagePerShot);
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log(coll);
            coll.gameObject.GetComponent<PlayerHealthHelper>().GetDamage(damagePerShot);
            Destroy(this.gameObject);
        } else if(coll.gameObject.CompareTag("sword"))
        {

            coll.gameObject.GetComponentInParent<WeaponHelper>().GetScore (scoreForDestroyIt);
            //add here start animation
            wasDestoed = true;
            Destroy(this.gameObject);
        }
    }

}

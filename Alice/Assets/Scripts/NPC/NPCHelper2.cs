using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHelper2 : MonoBehaviour
{

    public float FireRange = 20; //distance from which begining shoot

    public int damagePerShot = 20;
    public int scoreForDestroyIt = 2;

    public PlayerHealthHelper _target;//
    public PlayerHealthHelper Target
    {
        get { return _target; }
        set { _target = value; }
    }
    HealthHelper _healthHelper;
    PlayerShooting _gun;


    // Start is called before the first frame update
    void Start()
    {
        _healthHelper = GetComponent<HealthHelper>();
        _gun = GetComponentInChildren<PlayerShooting>();
        _target = GameObject.Find("Player").GetComponent<PlayerHealthHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(_target.transform.position.x, 0f, _target.transform.position.z);

       




        if (FireRange > Vector3.Distance(transform.position, _target.transform.position))
        {
            transform.LookAt(targetPos);
            if (!Target.Dead)
            {
                _gun.StartShoot();
            }            
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision);
            collision.gameObject.GetComponent<PlayerHealthHelper>().GetDamage(damagePerShot);
            Destroy(this.gameObject);
        }
        /*
        else if (collision.gameObject.CompareTag("sword"))
        {

            collision.gameObject.GetComponentInParent<WeaponHelper>().GetScore(scoreForDestroyIt);
            print("collision");
            //add here start animation
            Destroy(this.gameObject, 1);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sword"))
        {
            print("collision x");

            other.gameObject.GetComponentInParent<WeaponHelper>().GetScore(scoreForDestroyIt);
            //add here start animation
            Destroy(this.gameObject);
        }
    }

}

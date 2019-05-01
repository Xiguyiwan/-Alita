using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drug : MonoBehaviour
{
   

    [SerializeField] int Health=50;
    private GameObject player;
    private PlayerHealthHelper _playerHealth;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        _playerHealth = player.GetComponent<PlayerHealthHelper>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("sword"))
        {
            print("collision "+ coll);
            _playerHealth.AddHealth(Health);
            Destroy(this.gameObject);
        }
    }


}

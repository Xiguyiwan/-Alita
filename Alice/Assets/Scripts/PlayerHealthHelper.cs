using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHelper : MonoBehaviour
{

    public int MaxHealth = 100;
    public int Health = 100;

    private bool _dead;
    public bool Dead
    {
        get { return _dead; }
        set { _dead = value; }
    }

    public bool isDynamicHealthBarCreate = true;
    UIHealthBarHelper _uIHealthBarHelper;

    // Start is called before the first frame update
    void Awake()
    {
        if (isDynamicHealthBarCreate)
        {
            GameObject healtBarSlider = Instantiate(Resources.Load("HealthBarSlider"), Vector3.zero, Quaternion.identity) as GameObject;
            healtBarSlider.transform.SetParent(GameObject.Find("Canvas").transform);
            _uIHealthBarHelper = healtBarSlider.GetComponent<UIHealthBarHelper>();
            _uIHealthBarHelper.NPC = transform;
        }
    }

   
    public void GetDamage(int damage, HealthHelper killer)
    {
        if (Dead)
            return;

        Health -= damage;

        if (Health <= 0)
        {
            Dead = true;
            
           // GetComponent<Animator>().SetBool("Dead", true);
            
        }

    }

    public void GetDamage(int damage)
    {
        if (Dead)
            return;

        Health -= damage;

        if (Health <= 0)
        {
            Dead = true;


            //GetComponent<Animator>().SetBool("Dead", true);
            
            //GetComponent<Animator>().SetBool("Dead", true);
        }

    }
    public void AddHealth(int health)
    {
        print("call AddHealth");
        Health += health;

        if(Health> MaxHealth)
        {
            Health = MaxHealth;
        }
    }
    
}

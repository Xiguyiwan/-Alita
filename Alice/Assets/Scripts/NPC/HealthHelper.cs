using UnityEngine;
using System.Collections;
using System;

public class HealthHelper : MonoBehaviour
{

    public int MaxHealth = 100;
    public int Health = 100;
    public int Group = 0;

    public bool isDynamicHealthBarCreate = true;

    private bool _dead;
    public bool Dead
    {
        get { return _dead; }
        set { _dead = value; }
    }
    public PlayerShooting plShooting;

    public int Kills { get; private set; }

    UIHealthBarHelper _uIHealthBarHelper;
    // Use this for initialization
    void Start()
    {
        //if (isDynamicHealthBarCreate)
        //{
        //    GameObject healtBarSlider = Instantiate(Resources.Load("HealthBarSlider"), Vector3.zero, Quaternion.identity) as GameObject;
        //    healtBarSlider.transform.SetParent(GameObject.Find("Canvas").transform);
        //    _uIHealthBarHelper = healtBarSlider.GetComponent<UIHealthBarHelper>();
        //    _uIHealthBarHelper.NPC = transform;
        //}
        
        plShooting = GetComponentInChildren<PlayerShooting>();
    }

    

    public void GetDamage(int damage, HealthHelper killer)
    {
        print("call it");
        if (Dead)
            return;

        Health -= damage;

        if (Health <= 0)
        {
            Dead = true;
            killer.Kills += 1;
            GetComponentInChildren<PlayerShooting>().Drop();
            GetComponent<Animator>().SetBool("Dead",true);
            Destroy(_uIHealthBarHelper.gameObject);
        }

    }

    
}

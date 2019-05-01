using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPCHelper : MonoBehaviour {
    public float FireRange = 10; //расстояние, с которого начнем стрелять.

    private HealthHelper _target;
    
    public HealthHelper Target
    {
        get { return _target; }
        set { _target = value; }
    }


    HealthHelper _healthHelper;
    PlayerShooting _gun;

    // Use this for initialization
    void Start () {
        _healthHelper = GetComponent<HealthHelper>();
        StartCoroutine(Timer());
        _gun = GetComponentInChildren<PlayerShooting>();
	}


    //поиск врагов
    private IEnumerator Timer()
    {
        //найти всех персонажей, и добавить их в массив, если их группа отлична от собственной

        HealthHelper[] targets = GameObject.FindObjectsOfType<HealthHelper>().Where
            (p => p.Group != _healthHelper.Group).ToArray();

        if (targets.Length == 0)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(Timer());
        }
        else
        {
            //Выбрать рандомно одного из персонажей в этой группе.
            _target = targets[UnityEngine.Random.Range(0, targets.Length)];

            //если не мертв, продолжить поиск врагов через 5 сек
            if (!_healthHelper.Dead)//можно добавить дополнительное условие - если противник не мертв.
            {
                yield return new WaitForSeconds(5);
                StartCoroutine(Timer());
            }
        }
        

         
    }

    // Update is called once per frame
    void Update () {
        //Если цели нет или она мертва,или сам мертв, то отбой
        if (!_target||
            _healthHelper.Dead||
            _target.Dead)
            return;
        // если расстояние до цели меньше необходимого максимума, то можно стрелять.
        if (FireRange > Vector3.Distance(transform.position, _target.transform.position))
        {
            Vector3 targetPos = new Vector3(_target.transform.position.x, 0f, _target.transform.position.z);
            transform.LookAt(targetPos);
            float height = _target.GetComponent<CapsuleCollider>().height;
            Vector3 firePosition = new Vector3(_target.transform.position.x, 1.3f, _target.transform.position.z);
            //Returns a random point inside a sphere with radius 1 (Read Only).
            Vector3 RandomSph = UnityEngine.Random.insideUnitSphere * 1.5f;


            _gun.Body.transform.LookAt(firePosition+ RandomSph);

            _gun.StartShoot();
        }
	}
}

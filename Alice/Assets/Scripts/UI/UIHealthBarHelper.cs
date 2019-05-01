using UnityEngine;
using UnityEngine.UI;
using System.Collections;


// отвечает за получиние значений здоровья от ХилвХелпера и демонстрации 
//этих значений в слайдере. Также отвечает за местоположение слайдера над
//    персонажем
public class UIHealthBarHelper : MonoBehaviour
{
    Transform _nPC;
    public Transform NPC
    {
        get { return _nPC; }
        set
        {
            _nPC = value;
            _healthHelper = NPC.GetComponent<PlayerHealthHelper>();
            _slider = GetComponent<Slider>();
            _slider.maxValue = _healthHelper.MaxHealth;
        }
    }

    Slider _slider;
    PlayerHealthHelper _healthHelper;
    // Use this for initialization
    void Start()
    {
        GetComponent<RectTransform>().localPosition = new Vector3(0, 100f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!NPC)
            return;

        //Vector3 npcPos = new Vector3(NPC.position.x, NPC.position.y + 2.2f, NPC.position.z);
        /*GetComponent<RectTransform>().position = new Vector3(100, 2.5f, 0);*///Camera.main.WorldToScreenPoint(npcPos);

        _slider.value = _healthHelper.Health;
    }
}

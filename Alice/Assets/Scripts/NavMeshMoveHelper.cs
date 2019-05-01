using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NavMeshMoveHelper : MonoBehaviour
{

    public Transform EndPoint;

    NavMeshAgent _navMeshAgent;
    public HealthHelper _healthHelper;
    public NPCHelper2 _nPCHelper;
    // Use this for initialization
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _healthHelper = GetComponent<HealthHelper>();
        _nPCHelper = GetComponent<NPCHelper2>();
    }

    // Update is called once per frame
    void Update()
    {
        //если сам мертв, или Отсутствует хилв хелпер?, или мертв, то отмена
        if (_nPCHelper.Target.Dead||!_nPCHelper.Target||_healthHelper.Dead)
            EndPoint=this.transform;
        // if (_navMeshAgent.isOnOffMeshLink)
        //GetComponent<Animator>().SetBool("OffMeshLink", _navMeshAgent.isOnOffMeshLink);
        _navMeshAgent.SetDestination(EndPoint.position);
    }
}

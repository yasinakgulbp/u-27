using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    public NavMeshAgent _agent;
    [SerializeField] Transform _player;
    public LayerMask ground, player;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        if (_player != null)
        {
            _agent.SetDestination(_player.position);
        }
    }
}
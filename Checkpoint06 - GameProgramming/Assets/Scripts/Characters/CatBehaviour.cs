using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 currentDestination;

    void Start()
    {
        SetRandomDestination();
    }

    void Update()
    {
        MoveTowardsDestination();
    }

    void SetRandomDestination()
    {
        float x = Random.Range(-24, 24);
        float y = Random.Range(-24, 24);
        currentDestination = new Vector3(x, y);
    }

    void MoveTowardsDestination()
    {
        float step = moveSpeed * 5 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentDestination, step);
        if(transform.position == currentDestination)
        {
            SetRandomDestination();
        }
    }

}

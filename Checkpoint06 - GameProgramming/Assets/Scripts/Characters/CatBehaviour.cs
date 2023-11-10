using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatBehaviour : MonoBehaviour
{
    [SerializeField] Vector2 minPosition, maxPosition;
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
        float x = Random.Range(minPosition.x, maxPosition.x);
        float y = Random.Range(minPosition.y, maxPosition.y);
        currentDestination = new Vector3(x, y);
    }

    void MoveTowardsDestination()
    {
        float step = moveSpeed * 2 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentDestination, step);
        if(transform.position == currentDestination)
        {
            SetRandomDestination();
        }
    }

}

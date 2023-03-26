using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
  
    void Update()
    {
       if(transform.position != _target.position)
       {
         transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
       } 
    }
}

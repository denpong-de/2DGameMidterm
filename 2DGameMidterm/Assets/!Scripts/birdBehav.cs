﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class birdBehav : MonoBehaviour
{

    public Transform target;

    public float speed;
    //public float atkSpeed = 50;
    public float nextWayPointDistance; //How close to waypoint before pick a new one.

    public Transform Bird;
    Path Path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    Seeker Seeker;
    Rigidbody2D Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Seeker = GetComponent<Seeker>();
        Rigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("updatePath", 0.1f, 0.1f);
    }

    void updatePath()
    {
        if (Seeker.IsDone())
        {
            Seeker.StartPath(Rigidbody.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            Path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Path == null)
        {
            return;
        }
        if (currentWayPoint >= Path.vectorPath.Count)
        {
            //Rigidbody.AddForce(Vector2.left * atkSpeed);
            //Rigidbody.AddForce(Vector2.up * atkSpeed * 2);
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)Path.vectorPath[currentWayPoint] - Rigidbody.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        Rigidbody.AddForce(force);

        float distance = Vector2.Distance(Rigidbody.position, Path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }

        if (force.x >= 0.01f)
        {
            Bird.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            Bird.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}

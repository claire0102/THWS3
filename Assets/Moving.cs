using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    public bool move;

    [SerializeField] float speed;
    [SerializeField] int startPoint;
    [SerializeField] Transform[] points;


    int i;
    public bool reverse; // if reverse is true, the door is open/elevator is up(erdgeschoss), else the door is closed/elevator is down(cafeteria).


    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startPoint].position;
        i = startPoint;
    }

    // Update is called once per frame
    void Update()

    {

        if (Vector3.Distance(transform.position, points[i].position) < 0.01f)
        {
            move = false;

            if (i == points.Length - 1)
            {
                reverse = true;
                i--;
                return;
            }
            else if (i == 0)
            {
                reverse = false;
                i++;
                return;
            }

            if (reverse)
            {
                i--;
            }
            else
            {
                i++;
            }
        }

        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }

    }

}


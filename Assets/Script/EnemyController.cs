using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    private Transform homepos;
    private Transform target;
    [SerializeField]
    private float speed, maxRange, minRange;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = FindObjectOfType<Movement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) <= maxRange && Vector3.Distance(target.position, transform.position)>= minRange)
        {
        FollowPlayer();
        }
        else if(Vector3.Distance(transform.position,transform.position) <= maxRange)
        {
            GoHome();
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}

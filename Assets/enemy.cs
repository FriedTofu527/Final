using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public float num;
    public float jumpDistanceX = 0;
    public float jumpDistanceZ = 0;
    public float hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;

        if (num <= 0)
        {
            jumpDistanceX = Random.Range(-4f, 4f);
            jumpDistanceZ = Random.Range(-1f, 2f);

            //if (!Physics.Raycast(transform.position, Vector3.right, jumpDistanceX))
            //{
            //    jumpDistanceX = 0;
            //}

            //if (!Physics.Raycast(transform.position, Vector3.forward, jumpDistanceZ))
            //{
            //    jumpDistanceZ = 0;
            //}

            transform.Translate(new Vector3(jumpDistanceX, transform.position.y, jumpDistanceZ), Space.Self);
            num = Random.Range(1f, 2f);
        }

        if ()
        {
            hp--;
        }

        if (hp < 0)
        {
            Destroy(this);
        }

        num -= Time.deltaTime;
    }
}

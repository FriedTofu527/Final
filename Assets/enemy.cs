using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public GameObject winner;
    public GameObject self;
    public float num;
    public float jumpDistanceX = 0;
    public float jumpDistanceZ = 0;
    public float hp = 4;

    // Start is called before the first frame update
    void Start()
    {
        winner.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;

        if (num <= 0)
        {
            this.GetComponent<Renderer>().material.color = Color.white;
            jumpDistanceX = Random.Range(-4f, 4f);
            jumpDistanceZ = Random.Range(-1f, 3f);
            transform.Translate(new Vector3(jumpDistanceX, transform.position.y, jumpDistanceZ), Space.Self);
            num = Random.Range(1f, 2f);
        }

        num -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        hp--;

        this.GetComponent<Renderer>().material.color = Color.red;
        num = 0.2f;

        if (hp <= 0)
        {
            winner.SetActive(true);
            Destroy(self);
        }
    }
}

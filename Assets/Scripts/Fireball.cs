using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    Vector3 spawnPostition;

    void Start()
    {
        Range = 20f;
        Damage = 4;
        spawnPostition = transform.position;
        GetComponent<Rigidbody>().AddForce(Direction * 50f);
    }
    void Update()
    {
      if (Vector3.Distance(spawnPostition, transform.position) >= Range)
        {
            Extinghuish();
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Enemy")
        {
            col.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        Extinghuish();
    }
    void Extinghuish()
    {
        Destroy(gameObject);
    }
}


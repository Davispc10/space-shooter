using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
  private Rigidbody2D rd;
  [SerializeField] private float velocity;
  [SerializeField] private GameObject shotImpact;

  void Start()
  {
    rd = GetComponent<Rigidbody2D>();
    rd.velocity = new Vector2(0f, velocity);
  }

  void Update()
  {
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("EnemyOctopus")) {
      collision.GetComponent<EnemyController>().TakeDamage(1);
    } else if (collision.CompareTag("PlayerShip"))
    {
      collision.GetComponent<PlayerController>().TakeDamage(1);
    }
    Destroy(gameObject);
    Instantiate(shotImpact, transform.position, transform.rotation);
  }
}

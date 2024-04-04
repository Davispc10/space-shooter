using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody2D rd;
  [SerializeField] private int life = 3;
  [SerializeField] private float velocity = 5f;
  [SerializeField] private GameObject shot;
  [SerializeField] private Transform shotPosition;
  [SerializeField] private GameObject explosion;

  void Start()
  {
    rd = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    rd.velocity = new Vector2(horizontal, vertical).normalized * velocity;

    if (Input.GetButtonDown("Fire1"))
    {
      Instantiate(shot, shotPosition.position, Quaternion.identity);
    }
  }

  public void TakeDamage(int damagePoints)
  {
    life -= damagePoints;

    if (life <= 0)
    {
      Destroy(gameObject);
      Instantiate(explosion, transform.position, transform.rotation);
    }
  }
}

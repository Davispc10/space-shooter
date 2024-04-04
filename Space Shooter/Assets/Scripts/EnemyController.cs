using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  private Rigidbody2D rd;
  private float shotDelay = 1f;
  [SerializeField] private int life = 1;
  [SerializeField] private float velocity;
  [SerializeField] private GameObject shot;
  [SerializeField] private Transform shotPosition;
  [SerializeField] private GameObject explosion;

  void Start()
  {
    rd = GetComponent<Rigidbody2D>();
    rd.velocity = new Vector2(0f, -velocity);

    shotDelay = getDelayTime(0.5f, 2f);
  }

  void Update()
  {
    bool isChildrenVisible = GetComponentInChildren<SpriteRenderer>().isVisible;

    if (isChildrenVisible)
    {
      shotDelay -= Time.deltaTime;
      if (shotDelay <= 0)
      {
        Instantiate(shot, shotPosition.position, transform.rotation);
        shotDelay = getDelayTime(1.5f, 2f);
      }
    }
  }

  float getDelayTime(float min, float max)
  {
    return Random.Range(min, max);
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

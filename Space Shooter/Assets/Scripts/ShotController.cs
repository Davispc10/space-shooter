using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
  private Rigidbody2D rd;
  [SerializeField] private float velocity;
  void Start()
  {
    rd = GetComponent<Rigidbody2D>();
    rd.velocity = new Vector2(0f, velocity);
  }

  void Update()
  {
  }
}

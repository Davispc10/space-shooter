using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody2D rd;
  [SerializeField] private float velocity = 5f;

  [SerializeField] private GameObject shot;
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
      Instantiate(shot, transform.position, Quaternion.identity);
    }
  }
}

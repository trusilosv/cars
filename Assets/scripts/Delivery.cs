using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
  [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
  [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
  SpriteRenderer spriteRenderer;
   void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();  
  } 
  bool hasPackage = false;
  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log(other.collider.gameObject.name);
  }
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Package" && !hasPackage)
    {
      Destroy(other.gameObject, 0.5f);
      hasPackage = true;
      spriteRenderer.color = hasPackageColor;
    }
    if (other.tag == "Customer")
    {
      hasPackage = false;
      spriteRenderer.color = noPackageColor;
    }
  }
}

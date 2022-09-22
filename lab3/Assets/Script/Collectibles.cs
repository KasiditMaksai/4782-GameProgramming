using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
   [SerializeField] private SoCollectible collectibleObject;
   [SerializeField] private SpriteRenderer spriteRenderer;
   [SerializeField] private float delay = 4f;
   
   public CollectibleType color;

   private void Start()
   {
      if (TryGetComponent<CollectibleRandom>(out CollectibleRandom collectibleRandomize))
      {
         color = collectibleRandomize.color;
      }
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Player"))
      {
         spriteRenderer.enabled = false;
         Debug.Log(collectibleObject.GetCollectibleItem());
         StartCoroutine(Respawn());
      }
   }

   public IEnumerator Respawn()
   {
      yield return new WaitForSeconds(delay);
      spriteRenderer.enabled = true;
   }
   
}

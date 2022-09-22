using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collectibles : MonoBehaviour
{
   [SerializeField] private SoCollectible collectibleObject;
   
   public CollectibleType color;

   void Start()
   {
      Debug.Log(collectibleObject.GetCollectibleItem());
      if (TryGetComponent<CollectibleRandom>(out CollectibleRandom collectibleRandomize))
      {
         color = collectibleRandomize.color;
      }
   }

   CollectibleType getColor()
   {
      return this.color;
   }

   void setColor(CollectibleType color)
   {
      this.color = color;
   }
}

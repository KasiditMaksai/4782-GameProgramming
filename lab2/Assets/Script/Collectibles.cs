using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collectibles : MonoBehaviour
{
   public CollectibleType color;

   void Start()
   {
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

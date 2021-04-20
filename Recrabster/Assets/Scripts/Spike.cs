using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Crab {
    public class Spike : MonoBehaviour
    {
        public void End()
        {
            Destroy(gameObject);
        }
    }
}
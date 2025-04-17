using System.Collections.Generic;
using UnityEngine;

namespace McDonaldsValuables
{
    public class HappyMeal : MonoBehaviour
    {
        public List<GameObject> objectsToSpawn;
        public GameObject Obj;
        public bool Debug;

        public void Surprise()
        {
            if (objectsToSpawn == null || objectsToSpawn.Count == 0)
            {
                McDonaldsValuables.Logger.LogWarning("No object to spawn!");
                return;
            }

            int randomIndex = Random.Range(0, objectsToSpawn.Count);
            GameObject prefabToSpawn = objectsToSpawn[randomIndex];

            if (Debug)
                McDonaldsValuables.Logger.LogInfo("Obj spawn: " + prefabToSpawn.name);

            Instantiate(prefabToSpawn, Obj.transform.position, Quaternion.identity);
        }
    }
}

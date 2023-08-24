using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MouseButtonProcessor : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject prefabTeddyBear;


    // Reference to the spawned gameobject
    private GameObject spawnedTeddyBear; 


    // Camera Bounds
    private float minX = -10f;
    private float maxX = 10f;
    private float minY = -4f;
    private float maxY = 4f;

    private bool hasSpawned = false;
    private bool hasDestroyed = false;

    private Vector3 Pos = new Vector3();

	void Update()
	{
        Vector3 mousePos = Input.mousePosition;

        Pos = Camera.main.ScreenToWorldPoint(mousePos);

        float ClampedX = Mathf.Clamp(Pos.x, minX, maxX);
        float ClampedY = Mathf.Clamp(Pos.y, minY, maxY);

        Pos = new Vector3(ClampedX, ClampedY, 0f);

        HandleObject();
    }

    void HandleObject()
    {
        if (Input.GetAxis("SpawnTeddyBear") > 0 && hasSpawned == false)
        {
            spawnedTeddyBear = Instantiate(prefabTeddyBear, Pos, Quaternion.identity);
            hasSpawned = true;
            hasDestroyed = false;
        }

        else if (Input.GetAxis("SpawnTeddyBear") < 0 && hasDestroyed == false)
        {
            Destroy(spawnedTeddyBear);
            hasSpawned = false;
            hasDestroyed = true;
        }
    }

}

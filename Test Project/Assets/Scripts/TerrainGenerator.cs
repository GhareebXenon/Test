using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 50;     
    public int depth = 50;     
    public float scale = 10f;  
    public int seed = 12345;   
    public GameObject blockPrefab;

    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        Random.InitState(seed); 
        float offsetX = Random.Range(0f, 9999f);
        float offsetZ = Random.Range(0f, 9999f);
       
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float y = Mathf.PerlinNoise((x + offsetX) / scale, (z + offsetZ) / scale) * 10f;
                int height = Mathf.RoundToInt(y);

                for (int i = 0; i < height; i++)
                {
                    Vector3 pos = new Vector3(x, i, z);
                    Instantiate(blockPrefab, pos, Quaternion.identity, transform);
                }
            }
        }
    }
}

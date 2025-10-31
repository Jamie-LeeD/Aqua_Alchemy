using UnityEngine;
using UnityEngine.Tilemaps;

public class EnviroumentColour : MonoBehaviour
{
    public  Tilemap [] tMaps;
    public Color color;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (BioDecay.Instance.bioDecayPecent == 50.0f)
        {
            if (tMaps.Length > 0)
            {
                for (int i = 0; i < tMaps.Length; i++)
                {
                    tMaps[i].color = color;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BioDecay.Instance.bioDecayPecent == 100.0f)
        {
            if (tMaps.Length > 0)
            {
                for (int i = 0; i < tMaps.Length; i++)
                {
                    tMaps[i].color = Color.white;
                }
            }
        }
    }
}

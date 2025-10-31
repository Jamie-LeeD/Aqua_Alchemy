using UnityEngine;

public class StairsTrigger : MonoBehaviour
{
    public Direction direction;                                 //direction of the stairs
    [Space]
    public string layerUpper;
    public string sortingLayerUpper;
    [Space]
    public string layerLower;
    public string sortingLayerLower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public enum Direction
    {
        North,
        South,
        West,
        East
    }
}

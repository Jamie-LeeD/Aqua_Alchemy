using UnityEngine;

public class BioDecay : MonoBehaviour
{
    public static BioDecay Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] float bioDecayPecent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealBio(float heal)
    {
        bioDecayPecent += heal;
    }

    public void HurtBio(float heal)
    { 
        bioDecayPecent -= heal; 
    }
}

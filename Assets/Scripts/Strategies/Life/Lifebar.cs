using UnityEngine;

[RequireComponent(typeof(Actor))]
public class Lifebar : MonoBehaviour
{
    [SerializeField] private Transform fillSprite;
    public int MaxLife => GetComponent<Actor>().ActorStats.MaxLife;


    private float _currentLife;

    private Vector3 initialScale;

    void Start()
    {
        _currentLife = MaxLife;
        initialScale = fillSprite.localScale;
    }

    public void SetLife(float life)
    {
        _currentLife = Mathf.Clamp(life, 0, MaxLife);
        float lifePercent = _currentLife / MaxLife;

        fillSprite.localScale = new Vector3(initialScale.x * lifePercent, initialScale.y, initialScale.z);
    }

    // For testing
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SetLife(_currentLife - 20 * Time.deltaTime);
        }
    }
}

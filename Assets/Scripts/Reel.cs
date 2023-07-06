using UnityEngine;

public class Reel : MonoBehaviour
{
    [SerializeField] BoxCollider2D bc;
    [SerializeField] float minDuration;
    [SerializeField] float maxDuration;

    private GameObject[] fruits;
    private float duration;

    string wantedResult;

    public bool IsPlaying()
    {
        return duration >= 0.0f;
    }

    private void Awake()
    {
        fruits = new GameObject[transform.childCount];
        for (int i = 0; i < fruits.Length; ++i)
            fruits[i] = transform.GetChild(i).gameObject;
    }

    float GetTime()
    {
        return Random.Range(minDuration, maxDuration);
    }

    public void StartReel()
    {
        StartReel(null);
    }

    public void StartReel(string result)
    {
        wantedResult = result;

        duration = GetTime();
        bc.enabled = false;

        foreach (var mover in fruits)
        {
            mover.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -15);
        }
    }

    void StopReel()
    {
        Debug.Log("StopReel");
        foreach (var mover in fruits)
        {
            mover.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void Update()
    {
        duration -= Time.deltaTime;

        if (duration <= 0.0f)
        {
            bc.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.localPosition.y > -5.2 && collision.transform.localPosition.y < -4.4)
        {
            if (string.IsNullOrEmpty(wantedResult) || collision.name == wantedResult)
            {
                collision.transform.localPosition = new Vector2(collision.transform.localPosition.x, -4.8f);
                StopReel();
            }
        }
    }
}

using UnityEngine;
using UnityEngine.Rendering;

public class Ball : MonoBehaviour
{
    // [SerializeField] float forceStrength = 10f;
    Rigidbody2D rb;
    [SerializeField] public float shootForceX = 20f;
    [SerializeField] public float shootForceY = 10f;

    public ScoreSystem scoreSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (scoreSystem.switchHoop == true)
            {
                Vector2 force = new Vector2(shootForceX, shootForceY);
                rb.AddForce(force, ForceMode2D.Impulse);
            }

            if (scoreSystem.switchHoop == false)
            {
                Vector2 force = new Vector2(-shootForceX, shootForceY);
                rb.AddForce(force, ForceMode2D.Impulse);
            }

        }

    }
}

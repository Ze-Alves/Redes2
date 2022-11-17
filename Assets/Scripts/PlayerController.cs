using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    float xInput, yInput;
    new Rigidbody rigidbody;
    int Score;
    public GameObject winText;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (transform.position.y < -5)
            SceneManager.LoadScene(0);
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce( xInput * moveSpeed,0,yInput*moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Score++;
            other.gameObject.SetActive(false);
            
        }
        if (Score > 1)
            winText.SetActive(true);

    }
}

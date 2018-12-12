using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Uncomment this..
    //[Range(0f, 20f)]
    public float speed;
    public Text countText;
    public Text timerText;
    public Text winText;
    public int count;

    Rigidbody rb;
    float clock;

    // Use this for initialization
    // This will be run at first frame
    void Start()
    {
        clock = Time.time;
        timerText.text = clock.ToString();

        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
    }

    void Update()
    {
        clock += Time.deltaTime;
        timerText.text = clock.ToString();
    }

    // This is like update (which is called once per frame) but
    // this is run once per 'physics' frame. Use this to keep in sync
    // wtih physics engine.
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 vector = new Vector3(h, 0, v);

        rb.AddForce(vector * speed);
    }

    // This is called when this game objects collider comes in contact with
    // another collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    // Update our count text
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!\n" + "Time: " + clock.ToString();
        }
    }
}
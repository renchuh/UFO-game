using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D RD2D;

    public Text countText; //吃到幾顆黃金
    public Text winText; //贏了
    private int count;
    public AudioClip collect;
    private AudioSource Music;

    // Start is called before the first frame update
    void Start()
    {
        RD2D = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
        Music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        RD2D.AddForce(movement * Speed);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            Music.PlayOneShot(collect);
        }
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 14)
            winText.text = "You Win!";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Slider volumeSlider;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteDog, spriteCat, spriteChicken,spritePig,spriteGoat, spriteDefault;

    public RoadScript roadScript;
    public bool isStopped = false;

    public GameObject panel;

    public Vector3 originalPos;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (volumeSlider.value <1)
        {
            spriteRenderer.sprite = spriteDefault;

        }
        else if(volumeSlider.value >=1 && volumeSlider.value <= 3)
        {
            spriteRenderer.sprite = spriteDog;

        }
        else if(volumeSlider.value >3 && volumeSlider.value < 6)
        {
            spriteRenderer.sprite = spriteCat;
        }
        else if(volumeSlider.value >= 6 && volumeSlider.value < 9)
        {
            spriteRenderer.sprite = spriteChicken;
        }
        else if (volumeSlider.value >= 9 && volumeSlider.value <= 12)
        {
            spriteRenderer.sprite = spritePig;
        }
        else if (volumeSlider.value >12)
        {
            spriteRenderer.sprite = spriteGoat;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("WinningPoint"))
        {
            //roadScript.StopPlatform();
            Time.timeScale = 0;
            panel.SetActive(true);
            Debug.Log("You win!");
        }
        else if (collision.gameObject.CompareTag("Obstacle1"))
        {
            // Kiểm tra điều kiện cho vật cản 1
            if (volumeSlider.value >= 1 && volumeSlider.value < 3)
            {
                // Cho phép đi qua
                Debug.Log("Abc");
            }
            else
            {
                // Lùi lại
                StartCoroutine(roadScript.ReversePlatform());
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle2"))
        {
            // Kiểm tra điều kiện cho vật cản 2
            if (volumeSlider.value > 3 && volumeSlider.value <6)
            {
                // Cho phép đi qua
                Debug.Log("Passed Obstacle 2");
            }
            else
            {
                // Lùi lại
                StartCoroutine(roadScript.ReversePlatform());
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle3"))
        {
            // Kiểm tra điều kiện cho vật cản 3
            if (volumeSlider.value >= 6 && volumeSlider.value < 9)
            {
                // Cho phép đi qua
                Debug.Log("Passed Obstacle 3");
            }
            else
            {
                // Lùi lại
                StartCoroutine(roadScript.ReversePlatform());
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle4"))
        {
            // Kiểm tra điều kiện cho vật cản 4
            if (volumeSlider.value >= 9 && volumeSlider.value < 12)
            {
                // Cho phép đi qua
                Debug.Log("Passed Obstacle 4");
            }
            else
            {
                // Lùi lại
                StartCoroutine(roadScript.ReversePlatform());
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle5"))
        {
            // Kiểm tra điều kiện cho vật cản 5
            if (volumeSlider.value >= 12)
            {
                // Cho phép đi qua
                Debug.Log("Passed Obstacle 5");
            }
            else
            {
                // Lùi lại
                StartCoroutine(roadScript.ReversePlatform());
            }
        }

    }
}

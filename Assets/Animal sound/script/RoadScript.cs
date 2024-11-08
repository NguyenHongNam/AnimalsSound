using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RoadScript : MonoBehaviour
{
    public float force = 10f;
    public UnityEngine.UI.Slider volumeSlider;
    public float roadSpeed = 10f;
    private bool isStopped = false;
    public Rigidbody rb;

    private bool isReversing = false;
    public float reverseDistance = 2f; // Khoảng cách lùi lại khi va chạm
    public float reverseSpeed = 5f;    // Tốc độ lùi lại
    public float waitTime = 1f;

    private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStopped && !isReversing)
        {
            rb.velocity = new Vector3(0, 0, -roadSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        //if (collision.gameObject.CompareTag("WinningPoint"))
        //{
        //    isStopped = true;
        //}
        //else if (collision.gameObject.CompareTag("Player"))
        //{
        //    // Kiểm tra điều kiện cho vật cản 1
        //    if (volumeSlider.value > 1f && volumeSlider.value < 20f)
        //    {
        //        // Cho phép đi qua
        //        Debug.Log("Abc");
        //    }
        //    else
        //    {
        //        // Lùi lại
        //        StartCoroutine(ReversePlatform());
        //    }
        //}
        //else if (collision.gameObject.CompareTag("Player"))
        //{
        //    // Kiểm tra điều kiện cho vật cản 2
        //    if (volumeSlider.value > 20f && volumeSlider.value < 50f)
        //    {
        //        // Cho phép đi qua
        //        Debug.Log("Passed Obstacle 2");
        //    }
        //    else
        //    {
        //        // Lùi lại
        //        StartCoroutine(ReversePlatform());
        //    }
        //}
        //else if (collision.gameObject.CompareTag("Player"))
        //{
        //    // Kiểm tra điều kiện cho vật cản 3
        //    if (volumeSlider.value > 50f)
        //    {
        //        // Cho phép đi qua
        //        Debug.Log("Passed Obstacle 3");
        //    }
        //    else
        //    {
        //        // Lùi lại
        //        StartCoroutine(ReversePlatform());
        //    }
        //}
    }

    public IEnumerator ReversePlatform()
    {
        isReversing = true;

        // Lùi lại platform
        Vector3 reversePosition = transform.position + Vector3.forward * reverseDistance;
        while (Vector3.Distance(transform.position, reversePosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, reversePosition, reverseSpeed * Time.deltaTime);
            yield return null;
        }

        // Chờ trước khi tiếp tục di chuyển
        yield return new WaitForSeconds(waitTime);

        isReversing = false;
    }

    public void StopPlatform()
    {
        isStopped = true;
        rb.velocity = Vector3.zero;
    }
}

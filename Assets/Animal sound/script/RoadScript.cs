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
    public float roadSpeed = 50f;
    public bool isStopped = false;
    public Rigidbody rb;

    public bool isReversing = false;
    public float reverseDistance = 2f; // Khoảng cách lùi lại khi va chạm
    public float reverseSpeed = 5f;    // Tốc độ lùi lại
    public float waitTime = 1f;

    public Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopped && !isReversing)
        {
            StartPlatForm();
        }
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

    public void StartPlatForm()
    {
        rb.velocity = new Vector3(0, 0, -roadSpeed * Time.deltaTime);
    }
}

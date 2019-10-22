﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private float inactivatedRotationSpeed = 100, activatedRotationSpeed = 300;

    [SerializeField]
    private float inactivatedScale = 1, activatedScale = 1.5f;

    [SerializeField]
    private Color inactivatedColor, activatedColor;

    private bool isActivated = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    private void Update()
    {
        UpdateRotation();

    }

    private void UpdateColor()
    {
        Color color = inactivatedColor;
        if (isActivated)
            color = activatedColor;

        spriteRenderer.color = color;
    }

    private void UpdateScale()
    {
        float scale = inactivatedScale;

        if (isActivated)
        {
            scale = activatedScale;
        }

        transform.localScale = Vector3.one * scale;
    }

    private void UpdateRotation()
    {
        float rotationSpeed = inactivatedRotationSpeed;

        if (isActivated)
        {
            rotationSpeed = activatedRotationSpeed;
        }

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void SetIsActivated(bool value)
    {
        isActivated = value;
        UpdateScale();
        UpdateColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Something entered the checkpoint.");
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.SetCurrentCheckpoint(this);
        }
    }
}

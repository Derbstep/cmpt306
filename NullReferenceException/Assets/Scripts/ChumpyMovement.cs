﻿using UnityEngine;
using System.Collections;

public class ChumpyMovement : MonoBehaviour {
	// Movement speed for this unit
	[SerializeField] private float MovementSpeed = 5.0f;
	// Force to be added when this Chumpy jumps
	[SerializeField] private float JumpPower = 100.0f;
	// Mask containing blocks that are considered the ground
	[SerializeField] private LayerMask GroundMask;
	// The location that Chumpy will spawn/respawn at
	[SerializeField] private Transform SceneSpawn;

	public AudioClip JumpSound;

	private Rigidbody2D _rb2d;

	private bool _isGrounded;

	void Start() {
		// Instantiate Chumpy's GameObjects
		_rb2d = GetComponent<Rigidbody2D> ();
		Respawn ();
	}

	void Update () {
		// Update if Chumpy is on the ground or not
		_isGrounded = Physics2D.OverlapCircle (GetGroundCheck(), 0.2f, GroundMask);
	}

	public void Move(float x, float y) {
		Vector2 movement = new Vector2(x * MovementSpeed, _rb2d.velocity.y);
		_rb2d.velocity = movement;

	}

	// Jump for InputManager Script on mobile device
	public void Jump() {
		if (_isGrounded) {
			_rb2d.AddForce (new Vector2 (_rb2d.velocity.x, JumpPower));
			AudioSource.PlayClipAtPoint(JumpSound, transform.localPosition);
		}
	}

	void Respawn() {
		// Move to spawn
		_rb2d.position = SceneSpawn.position;
		// Remove all velocity
		_rb2d.velocity = Vector2.zero;
	}

	/*
	 * Calculate the point below Chumpy
	 */
	Vector2 GetGroundCheck() {
		return new Vector2 (_rb2d.position.x, _rb2d.position.y - 0.5f);
	}
		
}

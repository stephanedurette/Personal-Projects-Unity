using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    Rigidbody2D rigidBody;
    Animator animator;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float deathVelocityThreshold;
    [SerializeField] private LayerMask floorLayer;

    int walkingAnimHash = Animator.StringToHash("Walking");
    int jumpingAnimHash = Animator.StringToHash("Jumping");

    private void OnEnable()
    {
        EventManager.onPlayerDied += Die;
        EventManager.onGameWon += Win;
    }

    private void OnDisable()
    {
        EventManager.onPlayerDied -= Die;
        EventManager.onGameWon -= Win;
    }

    private void Die() {
        gameObject.SetActive(false);
    }

    private void Win() {
        gameObject.SetActive(false);
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        CheckFallDeath();
    }

    private void Move()
    {
        bool isGrounded = IsGrounded();

        float xMoveVelocity = Input.GetAxisRaw("Horizontal") * walkSpeed;
        float yMoveVelocity = Input.GetButtonDown("Jump") && isGrounded ? jumpVelocity : rigidBody.velocity.y;

        animator.SetBool(jumpingAnimHash, !isGrounded);
        animator.SetBool(walkingAnimHash, xMoveVelocity != 0 && isGrounded);

        spriteRenderer.flipX = xMoveVelocity > 0 ? false : xMoveVelocity < 0 ? true : spriteRenderer.flipX;

        rigidBody.velocity = new Vector2(xMoveVelocity, yMoveVelocity);
    }

    void CheckFallDeath() {
        if (rigidBody.velocity.y <= deathVelocityThreshold)
        {
            EventManager.onPlayerDied?.Invoke();
        }
    }

    bool IsGrounded(bool drawDebugBox = false) {
        Vector2 boxSize = Vector2.one;
        Vector2 boxOrigin = transform.position;

        var hit = Physics2D.BoxCast(boxOrigin, boxSize, 0, Vector2.down, 0, floorLayer);

        if (drawDebugBox) Helpers.DrawDebugBox(boxOrigin, boxSize, Color.red);

        return hit.collider != null;
    }
}
    
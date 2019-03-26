using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObjects : MonoBehaviour {

    // Use this for initialization

    public float            moveTime = 0.1f;
    public LayerMask        blockingPlayer;

    private BoxCollider2D   boxCollider;
    private Rigidbody2D     rb2D;
    private float           inverseMoveTime;

    protected virtual void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();

    }

}

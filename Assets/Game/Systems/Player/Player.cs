using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    private float movement = 0;
    private Rigidbody2D body;
    Vector3 gravityVelocity = Vector3.zero;
    public bool inDialoge = false;
    public LayerMask whereScan;
    public AudioClip walkSound, swapEdge, thinkSound;

    private Timer walkTimer = new Timer();
    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
        walkTimer.SetFrequency(1f);
    }
    private void Update()
    {
        Vector3 gravityDown = -transform.up * gravity;
        Vector3 offset = speed * movement * transform.right;
        gravityVelocity += (Vector3)gravityDown;
        if(!inDialoge)
        {
            body.MovePosition(transform.position + offset + gravityVelocity);

            if(walkTimer.Execute())
            {
                if(offset != Vector3.zero)
                {
                    walkTimer.SetFrequency(1f);
                    AudioManager.inst.Play(walkSound);
                }
            }

            transform.eulerAngles += new Vector3(0,0, Vector2.SignedAngle(transform.up,normal));

            if(Input.GetKeyDown(KeyCode.S) && Physics2D.OverlapCircle(transform.position + transform.up * -1,0.3f, whereScan) == null)
            {
                AudioManager.inst.Play(swapEdge);
                transform.Translate(transform.InverseTransformDirection(-normal) * 1);
                normal = -normal;
            }
        }
    }
    void FixedUpdate()
    {
        movement = Input.GetAxisRaw("Horizontal"); 
    }

    private Vector3 normal;
    private Vector3 n;
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.collider.gameObject.layer != 4) normal = collision2D.contacts[0].normal;
    }
    private void OnCollisionStay2D(Collision2D collision2D)
    {
        gravityVelocity = Vector2.zero;
    }
    public Vector3 Project(Vector3 forward)
    {
        return forward - Vector3.Dot(forward, normal) * normal;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position + transform.up * -1, 0.3f);
    }
}

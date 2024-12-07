using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int SPEED = 5;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] private float jumpForce = 600.0f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] Animator anim;
    [SerializeField] GameObject proj;
    [SerializeField] bool isShooting = false;

    void Start(){
        if(rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if(anim == null)
            anim = GetComponent<Animator>();
        proj = GameObject.FindGameObjectWithTag("Projectile");
    }
    void Update(){
        movement = Input.GetAxis("Horizontal");
        if(Input.GetKey("w")){
            jumpPressed = true;
        }
        if(Input.GetButtonDown("Jump")){
            isShooting = true;
        }
        anim.SetBool("Run", movement != 0);
    }
    private void FixedUpdate(){
        rigid.velocity = new Vector2(SPEED * movement, rigid.velocity.y);
        if(movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if(jumpPressed && isGrounded)
            Jump();
        else
            jumpPressed = false;

        if(isShooting){
            Projectile.Amount++;
            isShooting = false;
            shoot();
        }

    }
    public bool getFlip(){
        return isFacingRight;
    }
    private void shoot(){
        float direction = 1;
        Vector2 position = transform.position;
        GameObject projectile = Instantiate(proj, position, Quaternion.identity);
        Rigidbody2D projectileBody = projectile.GetComponent<Rigidbody2D>();
        if(isFacingRight){
            direction = 1;
        }
        else{
            direction = -1;
        }
        projectileBody.velocity = new Vector3(direction * 7f, 0f, 0f);
    }
    private void Flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump(){
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            isGrounded = true;
        }
        else{
            isGrounded = false;
        }

        if(collision.gameObject.tag == "KILLZONE"){
            SceneManager.LoadScene(PersistentData.Instance.getLevel());
        }
    }
}

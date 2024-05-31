using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEditor.IMGUI.Controls;
using TMPro;
using UnityEngine.SceneManagement;
namespace ClearSky
{
    public class SimplePlayerController : MonoBehaviour
    {
        public int hp = 0;
        public int max_hp = 0;
        public float movePower = 10f;
        public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        public GameObject fireballPrefab;
        public Image hp_bar;
        private bool isNail = false;
        private bool isCeiling = false;
        [SerializeField] TextMeshProUGUI ScoreText;
        public int score;
        float scoreTime;
        Vector3 movement;
        public GameObject currentFloor;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;
        private bool isHurt = false;
        private bool hasHeal = false;
        private AudioSource deathSound;
        [SerializeField] GameObject replayButton;
        [SerializeField] GameObject ExitButton;
        public GameObject gameOver;

        // Start is called before the first frame update
        void Start()
        {
            max_hp = 20;
            hp = max_hp;
            score = 0;
            scoreTime = 0f;
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            deathSound = GetComponent<AudioSource>();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
                Jump();
                Run();
            }
            UpdateScore();

        float _percentage = (float)hp/(float)max_hp;
        hp_bar.transform.localScale = new Vector3(_percentage,hp_bar.transform.localScale.y,hp_bar.transform.localScale.z);
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if(coll.gameObject.tag == "monster"){
            ModifyHp(-2);
        }
            if(coll.gameObject.tag == "DeathLine"){
                hp = 0;
            }
            anim.SetBool("isJump", false);
        }
        void OnCollisionEnter2D(Collision2D coll){

        if(coll.gameObject.tag == "Normal"){
            if(currentFloor == coll.gameObject && hasHeal){
                return;
            }
            if(coll.contacts[0].normal == new Vector2(0f,1f)){
                currentFloor = coll.gameObject;
                ModifyHp(2);
                coll.gameObject.GetComponent<AudioSource>().Play();
                hasHeal = true;
            }
        }
        else if(coll.gameObject.tag == "Nail"){
            if(coll.contacts[0].normal == new Vector2(0f,1f)){
                currentFloor = coll.gameObject;
                ModifyHp(-3);
                coll.gameObject.GetComponent<AudioSource>().Play();
                isNail = true;
            }
        }
        else if(coll.gameObject.tag == "ceiling"){
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
            ModifyHp(-3);
            coll.gameObject.GetComponent<AudioSource>().Play();
            isCeiling = true;
        }
        else if(coll.gameObject.tag == "Trampoline"){
            if(coll.contacts[0].normal == new Vector2(0f,1f)){
                currentFloor = coll.gameObject;
                coll.gameObject.GetComponent<AudioSource>().Play();
                rb.AddForce(new Vector2(0f, 20f), ForceMode2D.Impulse);
            }
        }
        else if(coll.gameObject.tag == "conveyorLeft"){
             if(coll.contacts[0].normal == new Vector2(0f,1f)){
                currentFloor = coll.gameObject;
            }
        }
        else if(coll.gameObject.tag == "conveyorRight"){
             if(coll.contacts[0].normal == new Vector2(0f,1f)){
                currentFloor = coll.gameObject;
            }
        }
        }

        void OnCollisionStay2D(Collision2D coll){
        if (coll.gameObject.CompareTag("conveyorLeft")){
            if (coll.contacts[0].normal == new Vector2(0f, 1f)){
            rb.velocity = new Vector2(-movePower, rb.velocity.y);
            }
        }
        else if (coll.gameObject.CompareTag("conveyorRight")){
            if (coll.contacts[0].normal == new Vector2(0f, 1f)){
            rb.velocity = new Vector2(movePower, rb.velocity.y);
            }
        }
        }
        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0) && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
            isJumping = false;
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
            GameObject bullet = Instantiate(fireballPrefab,this.transform.position+ Vector3.up * 3f,Quaternion.identity);
            fireballController fireball =bullet.GetComponent<fireballController>() as fireballController;
                anim.SetTrigger("attack");
                if(direction == -1){
                    fireball.Right = false;
                }
            }
        }
        void Hurt()
        {
            if (isHurt)
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);

                if(isNail){
                    rb.AddForce(new Vector2(0f, 15f), ForceMode2D.Impulse);
                    isNail = false;
                }
                else if(isCeiling){
                    rb.AddForce(new Vector2(0f, -10f), ForceMode2D.Impulse);
                    isCeiling = false;
                }

            }
            isHurt = false;
        }
        void Die()
        {
            if (hp == 0)
            {
                anim.SetTrigger("die");
                deathSound.Play();
                alive = false;
                replayButton.SetActive(true);
                gameOver.SetActive(true);
                ExitButton.SetActive(true);

                Time.timeScale = 0.5f;
            }
        }
        void Restart()
        {
            if(Input.GetKeyDown(KeyCode.Alpha0)){
                anim.SetTrigger("idle");
                alive = true;
            }
        }

        void ModifyHp(int num){
            hp += num;
            if(num < 0){
                isHurt = true;
            }
            if(hp > 20){
                hp = 20;
            }else if(hp < 0){
                hp = 0;
            }
        }

        void UpdateScore(){
            scoreTime += Time.deltaTime;
            if(scoreTime > 2f){
                score++;
                scoreTime = 0f;
                ScoreText.text = "UnderGround: "+score.ToString();
            }
        }
    }
}
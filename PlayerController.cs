using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 750.0f;
    float walkfForce = 40.0f;
    float maxWalkSpeed = 6.0f;
    Animator animator;

    public AudioClip getCoin;
    AudioSource aud;

    GameObject director;

    float scale = 1.0f;


    //충돌 판정
    void OnTriggerEnter2D(Collider2D other)
    {
        aud.PlayOneShot(getCoin);

        if (other.gameObject.tag == "Bronze")
        {
            this.director.GetComponent<GameDirector>().getBronze();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Silver")
        {
            this.director.GetComponent<GameDirector>().getSilver();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Gold")
        {
            this.director.GetComponent<GameDirector>().getGold();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Flag")
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().clearGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //점프
        //if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
            
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //좌우이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //플레이어의 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //스피드 제한
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkfForce);
        }

        //움직이는 방향에 따라 이미지 반전
        if (key != 0)
        {
            transform.localScale = new Vector3(key*scale, scale, 1);
        }

        //플레이어 속도에 맞춰 애니메이션 속도를 바꿈
        this.animator.speed = speedx / 5.0f;

        if (transform.position.y < -50)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

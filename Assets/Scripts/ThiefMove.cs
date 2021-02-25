using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThiefMove : MonoBehaviour
{

    static public ThiefMove instance;

    public float speed;
    Rigidbody2D rigid;

    Transform enemy1;
    Transform enemy2;
    Transform enemy3;
    Transform enemy4;
    Transform enemy5;

    Transform enemy11;
    Transform enemy12;
    Transform enemy13;

    Transform enemy101;

    Transform enemy201;
    Transform enemy202;

    Transform enemy301;
    Transform enemy401;

    float h;
    float v;
    float timer = 0;
    float timerWalk = 0;

    bool timerReached = false;
    bool isHorizontalMove;

    public bool getKey1 = false;
    public bool getKey2 = false;
    public bool getKey3 = false;

    public bool isDialog = false;

    public string currentMapName;
    public string transferPointName; 
    public bool gameover = false;
    public bool gameclear = false;

    public AudioClip[] Music = new AudioClip[9];
    AudioSource bgm;

    public bool mapChanged = false;

    public Text keyLeft;

    public bool isChased;

    int sceneID;
    Animator animator;

    public int randomKey1;
    public int randomKey2;
    public int randomKey3;

    void Start(){

        animator = gameObject.GetComponentInChildren<Animator>();

        bgm = this.GetComponent<AudioSource>();
        keyLeft = GameObject.Find("KeyScore").GetComponent<Text>();
        keyLeft.text = ScoreManager.leftkey().ToString() + " left";
        
        sceneID = SceneManager.GetActiveScene().buildIndex;

        if(instance == null){
            DontDestroyOnLoad(this.gameObject);
            instance = this;
            Play_zero();
        }
        else{
            Destroy(this.gameObject);
        }

        randomKey1 = Random.Range(0, 4);
        randomKey2 = Random.Range(0, 4);
        randomKey3 = Random.Range(0, 4);
    }

    void Awake() {

        rigid = GetComponent<Rigidbody2D>();
    }

    void Update() {

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if(hDown || vUp)
            isHorizontalMove = true;
        else if(vDown || hUp)
            isHorizontalMove = false;


        sceneID = SceneManager.GetActiveScene().buildIndex;

        if(sceneID == 1 || sceneID == 2)
        {
            Debug.Log("Start");
            enemy1 = GameObject.Find("Police1").GetComponent<Transform>();
            enemy2 = GameObject.Find("Police2").GetComponent<Transform>();
            enemy3 = GameObject.Find("Police3").GetComponent<Transform>();
            enemy4 = GameObject.Find("Police4").GetComponent<Transform>();
            enemy5 = GameObject.Find("Police5").GetComponent<Transform>();

            float distance1 = Vector3.Distance(enemy1.position, transform.position);
            float distance2 = Vector3.Distance(enemy2.position, transform.position);
            float distance3 = Vector3.Distance(enemy3.position, transform.position);
            float distance4 = Vector3.Distance(enemy4.position, transform.position);
            float distance5 = Vector3.Distance(enemy5.position, transform.position);

            if(distance1 <= 4.2f || distance2 <= 4.2f || distance3 <= 4.2f ||
                distance4 <= 4.2f || distance5 <= 4.2f)
            {
                if(bgm.clip == Music[0] && bgm.isPlaying)
                {
                    Stop_zero();
                    Play_first();
                }
                else if(bgm.clip == Music[2] && bgm.isPlaying)
                {
                    Stop_second();
                    Play_first();
                }
                if(mapChanged)
                {
                    Debug.Log("Hi");
                    Stop_first();
                    Play_zero();
                    mapChanged = false;
                }
            }
            else if((distance1 >= 4.2f && distance1 <= 8.0f) || (distance2 >= 4.2f && distance2 <= 8.0f) 
                    || (distance3 >= 4.2f && distance3 <= 8.0f) || (distance4 >= 4.2f && distance4 <= 8.0f)
                    || (distance5 >= 4.2f && distance5 <= 8.0f))
            {
                if(bgm.clip == Music[0] && bgm.isPlaying)
                {
                    Stop_zero();
                    Play_second();
                }
                else if(bgm.clip == Music[1] && bgm.isPlaying)
                {
                    Stop_first();
                    Play_second();
                }
                if(mapChanged)
                {
                    Debug.Log("Hi");
                    Stop_second();
                    Play_zero();
                    mapChanged = false;
                }
            }
            else 
            {
                if(bgm.clip == Music[1] && bgm.isPlaying)
                {
                    if(!timerReached)
                        timer += Time.deltaTime;
                    if(!timerReached && timer > 1)
                    {
                        Stop_first();
                        Play_zero();
                        timer = 0;
                    }
                    if(mapChanged)
                    {
                        Debug.Log("Hi");
                        Stop_first();
                        Play_zero();
                        mapChanged = false;
                    }
                
                }
                else if(bgm.clip == Music[2] && bgm.isPlaying)
                {
                    if(!timerReached)
                        timer += Time.deltaTime;
                    if(!timerReached && timer > 1)
                    {
                        Stop_second();
                        Play_zero();
                        timer = 0;
                    }
                    if(mapChanged)
                    {
                        Debug.Log("Hi");
                        Stop_second();
                        Play_zero();
                        mapChanged = false;
                    }
                
                }
            }
        }
        else if(sceneID == 4 || sceneID == 17)
        {
            Debug.Log("Welcome");
            enemy11 = GameObject.Find("Police11").GetComponent<Transform>();
            enemy12 = GameObject.Find("Police12").GetComponent<Transform>();
            enemy13 = GameObject.Find("Police13").GetComponent<Transform>();
            
            float distance11 = Vector3.Distance(enemy11.position, transform.position);
            float distance12 = Vector3.Distance(enemy12.position, transform.position);
            float distance13 = Vector3.Distance(enemy13.position, transform.position);
           
            if(distance11 <= 4.2f || distance12 <= 4.2f || distance13 <= 4.2f)
            {
                if(bgm.clip == Music[0] && bgm.isPlaying)
                {
                    Stop_zero();
                    Play_first();
                }
                else if(bgm.clip == Music[2] && bgm.isPlaying)
                {
                    Stop_second();
                    Play_first();
                }
                if(mapChanged)
                {
                    Debug.Log("Hi");
                    Stop_first();
                    Play_zero();
                    mapChanged = false;
                }
            }
            else if((distance11 >= 4.2f && distance11 <= 8.0f) || (distance12 >= 4.2f && distance12 <= 8.0f) 
                    || (distance13 >= 4.2f && distance13 <= 8.0f))
            {
                 if(bgm.clip == Music[0] && bgm.isPlaying)
                {
                    Stop_zero();
                    Play_second();
                }
                else if(bgm.clip == Music[1] && bgm.isPlaying)
                {
                    Stop_first();
                    Play_second();
                }
                if(mapChanged)
                {
                    Debug.Log("Hi");
                    Stop_second();
                    Play_zero();
                    mapChanged = false;
                }
            }
            else 
            {
                if(bgm.clip == Music[1] && bgm.isPlaying)
                {
                    if(!timerReached)
                        timer += Time.deltaTime;
                    if(!timerReached && timer > 1)
                    {
                        Stop_first();
                        Play_zero();
                        timer = 0;
                    }
                    if(mapChanged)
                    {
                        Debug.Log("Hi");
                        Stop_first();
                        Play_zero();
                        mapChanged = false;
                    }
                
                }
                else if(bgm.clip == Music[2] && bgm.isPlaying)
                {
                    if(!timerReached)
                        timer += Time.deltaTime;
                    if(!timerReached && timer > 1)
                    {
                        Stop_second();
                        Play_zero();
                        timer = 0;
                    }
                    if(mapChanged)
                    {
                        Debug.Log("Hi");
                        Stop_second();
                        Play_zero();
                        mapChanged = false;
                    }
                
                }
            }
        }
        else if(sceneID == 8 || sceneID == 16 | sceneID == 18)
        {
            Debug.Log("Welcome");
            enemy201 = GameObject.Find("Police201").GetComponent<Transform>();
            enemy202 = GameObject.Find("Police202").GetComponent<Transform>();
            
            float distance201 = Vector3.Distance(enemy201.position, transform.position);
            float distance202 = Vector3.Distance(enemy202.position, transform.position);
           
            if(distance201 <= 4.2f || distance202 <= 4.2f)
            {
                if(bgm.clip == Music[0] && bgm.isPlaying)
                {
                    Stop_zero();
                    Play_first();
                }
                else if(bgm.clip == Music[2] && bgm.isPlaying)
                {
                    Stop_second();
                    Play_first();
                }
                if(mapChanged)
                {
                    Debug.Log("Hi");
                    Stop_first();
                    Play_zero();
                    mapChanged = false;
                }
            }
            else if((distance201 >= 4.2f && distance201 <= 7.0f) || (distance202 >= 4.2f && distance202 <= 7.0f))
            {
                 if(bgm.clip == Music[0] && bgm.isPlaying)
                {
                    Stop_zero();
                    Play_second();
                }
                else if(bgm.clip == Music[1] && bgm.isPlaying)
                {
                    Stop_first();
                    Play_second();
                }
                if(mapChanged)
                {
                    Debug.Log("Hi");
                    Stop_second();
                    Play_zero();
                    mapChanged = false;
                }
            }
            else 
            {
                if(bgm.clip == Music[1] && bgm.isPlaying)
                {
                    if(!timerReached)
                        timer += Time.deltaTime;
                    if(!timerReached && timer > 1)
                    {
                        Stop_first();
                        Play_zero();
                        timer = 0;
                    }
                    if(mapChanged)
                    {
                        Debug.Log("Hi");
                        Stop_first();
                        Play_zero();
                        mapChanged = false;
                    }
                
                }
                else if(bgm.clip == Music[2] && bgm.isPlaying)
                {
                    if(!timerReached)
                        timer += Time.deltaTime;
                    if(!timerReached && timer > 1)
                    {
                        Stop_second();
                        Play_zero();
                        timer = 0;
                    }
                    if(mapChanged)
                    {
                        Debug.Log("Hi");
                        Stop_second();
                        Play_zero();
                        mapChanged = false;
                    }
                
                }
            }
        }
        else if(sceneID == 6 || sceneID == 7 || sceneID == 9 || sceneID == 10 || 
                sceneID == 11 ||sceneID == 12 || sceneID == 14)
        {
            Debug.Log("Welcome");
            enemy301 = GameObject.Find("Police301").GetComponent<Transform>();
            
            float distance301 = Vector3.Distance(enemy301.position, transform.position);
           
            if(distance301 <= 4.2f)
            {
               if(bgm.clip == Music[0] && bgm.isPlaying)
                {
                    Stop_zero();
                    Play_first();
                }
                else if(bgm.clip == Music[2] && bgm.isPlaying)
                {
                    Stop_second();
                    Play_first();
                }
                if(mapChanged)
                {
                    Debug.Log("Hi");
                    Stop_first();
                    Play_zero();
                    mapChanged = false;
                }
            }
            else if(distance301 >= 4.2f && distance301 <= 7.0f)
            {
                 if(bgm.clip == Music[0] && bgm.isPlaying)
                {
                    Stop_zero();
                    Play_second();
                }
                else if(bgm.clip == Music[1] && bgm.isPlaying)
                {
                    Stop_first();
                    Play_second();
                }
                if(mapChanged)
                {
                    Debug.Log("Hi");
                    Stop_second();
                    Play_zero();
                    mapChanged = false;
                }
            }
            else 
            {
                if(bgm.clip == Music[1] && bgm.isPlaying)
                {
                    if(!timerReached)
                        timer += Time.deltaTime;
                    if(!timerReached && timer > 1)
                    {
                        Stop_first();
                        Play_zero();
                        timer = 0;
                    }
                    if(mapChanged)
                    {
                        Debug.Log("Hi");
                        Stop_first();
                        Play_zero();
                        mapChanged = false;
                    }
                
                }
                else if(bgm.clip == Music[2] && bgm.isPlaying)
                {
                    if(!timerReached)
                        timer += Time.deltaTime;
                    if(!timerReached && timer > 1)
                    {
                        Stop_second();
                        Play_zero();
                        timer = 0;
                    }
                    if(mapChanged)
                    {
                        Debug.Log("Hi");
                        Stop_second();
                        Play_zero();
                        mapChanged = false;
                    }
                
                }
            }
        }
        else if(sceneID == 19)
        {
            if(bgm.clip == Music[0] && bgm.isPlaying)
            {
                Stop_zero();
                Play_ending();
            }
            if(bgm.clip == Music[1] && bgm.isPlaying)
            {
                Stop_first();
                Play_ending();
            }
            if(bgm.clip == Music[2] && bgm.isPlaying)
            {
                Stop_second();
                Play_ending();
            }
        }
       
        
       
    }

    void FixedUpdate() {
      
      Vector2 moveVec = 
        isHorizontalMove ? new Vector2(h, 0) : new Vector2(0, v);

      if(isHorizontalMove && h > 0)
      {
          animator.SetInteger("Direction", 2);
      } 
      else if(isHorizontalMove && h < 0)
      {
          animator.SetInteger("Direction", 1);
      } 
      else if(!isHorizontalMove && v > 0)
      {
          animator.SetInteger("Direction", 4);
      } 
      else if(!isHorizontalMove && v < 0)
      {
          animator.SetInteger("Direction", 3);
      }

      rigid.velocity = moveVec * speed;
      if(rigid.velocity != Vector2.zero){
        timerWalk += Time.deltaTime;
        if(timerWalk > 0.3)
        {
            Play_walk();
            timerWalk = 0;
        }
      }
      else {
           animator.SetInteger("Direction", 0);
      }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Door"){

           Play_door();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Police"){
            Debug.Log("GameOver");
            gameover = true;
            Stop_zero();
            Stop_first();
            Stop_second();
            Play_third();
            SceneManager.LoadScene("GameOver Scene");
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Key1"){
           ScoreManager.setScore(1);
           Play_key();
           collision.gameObject.SetActive(false);
           getKey1 = true;
           keyLeft.text = ScoreManager.leftkey().ToString() + " left";
        }

        if(collision.gameObject.tag == "Key2"){
           ScoreManager.setScore(1);
           Play_key();
           collision.gameObject.SetActive(false);
           getKey2 = true;
           keyLeft.text = ScoreManager.leftkey().ToString() + " left";
        }

        if(collision.gameObject.tag == "Key3"){
           ScoreManager.setScore(1);
           Play_key();
           collision.gameObject.SetActive(false);
           getKey3 = true;
           keyLeft.text = ScoreManager.leftkey().ToString() + " left";
        }

        if(collision.gameObject.tag == "Goose"){
           Play_goose();
        }

        if(collision.gameObject.tag == "Ending"){
            
            SceneManager.LoadScene("Game Clear");
            Destroy(this.gameObject);
        }
    }

    void Play_zero()
    {
        if(!bgm.isPlaying)
        {
            bgm.loop = true;
            bgm.clip = Music[0];
            bgm.Play();
        }
        
    }

    void Play_first()
    {
        if(!bgm.isPlaying)
        {
            bgm.loop = true;
            bgm.clip = Music[1];
            bgm.Play();
        }
        
    }

    void Play_second()
    {
        if(!bgm.isPlaying)
        {
            bgm.loop = true;
            bgm.clip = Music[2];
            bgm.Play();
        }
        
    }

    void Play_third()
    {
        if(!bgm.isPlaying)
        {
            bgm.loop = true;
            bgm.clip = Music[3];
            bgm.Play();
        }
        
    }

    void Play_ending()
    {
        if(!bgm.isPlaying)
        {
            bgm.loop = true;
            bgm.clip = Music[8];
            bgm.Play();
        }
        
    }

    void Play_key()
    {
        // bgm.clip = Music[4];
        bgm.PlayOneShot(Music[4]);
    }

    void Play_door()
    {
        // bgm.clip = Music[5];
        bgm.PlayOneShot(Music[5]);
    }

    void Play_goose()
    {
        // bgm.clip = Music[5];
        bgm.PlayOneShot(Music[7]);
    }

    void Play_walk()
    {
        // bgm.clip = Music[5];
        bgm.PlayOneShot(Music[6]);
        
    }

    void Stop_zero()
    {
        bgm.clip = Music[0];
        bgm.Stop();
    }

    void Stop_first()
    {
        bgm.clip = Music[1];
        bgm.Stop();
    }

    void Stop_second()
    {
        bgm.clip = Music[2];
        bgm.Stop();
    }

    void Stop_third()
    {
        bgm.clip = Music[3];
        bgm.Stop();
    }

    void doNothing(){
        Debug.Log("Delay");
    }

    void changeMap(){
        mapChanged = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class PlayableCharacter : MonoBehaviour
{

    public int damage;
    public float speed;
    public float jumpHeight;
    int JumpCount;

    Rigidbody2D rigid;

    public int MaxHp;
    private int Hp;
    public int _Hp
    {
        get { return Hp; }
        set
        {
            Mathf.Clamp(value, 0, MaxHp);
            if (value <= 0)
            {
                Debug.Log(gameObject.name + " ���");
                Die();
            }
            Hp = value;
        }
    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        JumpCountManage();
    }
    protected virtual void FixedUpdate()
    {
        InputManager();
    }
    protected virtual void InputManager()
    {
        //�÷��̾� �¿� ������
        Move();
        //�÷��̾� ����
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        //�÷��̾� �ൿ
        if (Input.GetKeyDown(KeyCode.J))
            Attack();
        if (Input.GetKeyDown(KeyCode.K))
            Skill1();
        if (Input.GetKeyDown(KeyCode.K))
            Skill2();
        if (Input.GetKeyDown(KeyCode.O))
            Ultimate();
    }
    void Move()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        Vector3 dir = Horizontal * Vector3.right * speed * Time.deltaTime;
        rigid.AddForce(dir, ForceMode2D.Impulse);
    }
    protected virtual void JumpCountManage()
    {
        Physics2D.RaycastAll(transform.position, Vector2.down * transform.);
    }
    protected virtual void Jump()
    {
        if (JumpCount > 0)
        {
            Vector3 dir = Vector3.up * jumpHeight;
            rigid.AddForce(dir, ForceMode2D.Impulse);
            JumpCount--;
        }
    }
    protected virtual void Die()
    {

    }
    protected virtual void Attack()
    {

    }
    protected virtual void Skill1()
    {

    }
    protected virtual void Skill2()
    {

    }
    protected virtual void Ultimate()
    {

    }
    protected virtual void Gaurd()
    {

    }
}

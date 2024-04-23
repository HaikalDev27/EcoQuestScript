using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControler : MonoBehaviour
{
    [Header("Movement")]
    Rigidbody2D rb;
	public float ms;
    public int pos;
	public float jf;
	[SerializeField] private LayerMask gdLayerMask;
	private BoxCollider2D boxcolider2d;
    public bool canMove = true;
    bool isMoving = false;
    public AudioSource walkSfx;

    Animator anim;
    [Header("Input")]
    [SerializeField] KeyCode OpenBook = KeyCode.E;
    public Interactable interactable;

    [Header("UserInterface")]
    [SerializeField] GameObject Book;
    public Animator bookAnimator;
    [SerializeField] float BookExitTime;
    [SerializeField] GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		boxcolider2d = transform.GetComponent<BoxCollider2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = SimpleInput.GetAxisRaw("Horizontal");

        if (canMove)
        {
            rb.velocity = new Vector2(horiz * ms, rb.velocity.y);
            anim.SetFloat ("speed", Mathf.Abs (horiz), 0.1f, Time.deltaTime);    

		    if (horiz > 0 || horiz < 0) {
			    transform.localScale = new Vector2 (0.5f * horiz, 0.5f);
    		}

        }

        if (rb.velocity.x != 0)
        {
            isMoving = true;
        } else {
            isMoving = false;
        }

        if (isMoving)
        {
            if (!walkSfx.isPlaying)
            {
                walkSfx.Play();
            }
        } else
        {
            walkSfx.Stop();
        }
    }

    public void Jump(){
        if (canMove){
            if(IsGrounded){
                rb.velocity = Vector2.up * jf;
                FindFirstObjectByType<AudioManager>().Play("Jump");
            }
        }
    }

    public void OpeningBook(){
        if (Book.activeInHierarchy)
        {
            canMove = true;
            StartCoroutine(ClosedBook());
        }
        else
        {
            canMove = false;
            StartCoroutine(OpenedBook());
        }

    }

    IEnumerator OpenedBook(){
        anim.SetBool("isBook", true);
        yield return new WaitForSeconds(BookExitTime);
        Book.SetActive(true);
        bookAnimator.SetBool("isBookOpen", true);
    }

    IEnumerator ClosedBook(){
        bookAnimator.SetBool("isBookOpen", false);
        yield return new WaitForSeconds(BookExitTime);
        Book.SetActive(false);
        anim.SetBool("isBook", false);
    }

    private bool IsGrounded(){
		RaycastHit2D raycast = Physics2D.BoxCast (boxcolider2d.bounds.center, boxcolider2d.bounds.size, 0f, Vector2.down, 1f, gdLayerMask);
		return raycast.collider != null;
	}
}

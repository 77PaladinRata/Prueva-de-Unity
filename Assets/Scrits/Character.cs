using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using DG.Tweening;

public class Character : MonoBehaviour
{
    private Rigidbody characterRigidbody;
    //* Mas scrips nuevos
    [SerializeField]
    private CharacterData characterData;
    [SerializeField]
    private Animator characterAnimator;
    //*
    [SerializeField]
    private float jumForce = 5f;
    [SerializeField]
    private float distanceToMove = 2f;
    [SerializeField]    //* 
    private float moveDuration = 0.2f;  //* 
    //* Nueva
    [SerializeField] 
    private Transform characterStartPivot;
    /// <summary>
    /// Agregando nuevas para el Sonido
    /// </summary>
    [SerializeField] 
    private UnityEvent onJump;
    [SerializeField] 
    private UnityEvent onMoveToSide;
    [SerializeField] 
    private UnityEvent onRoll;
    //* // Sonidos Nuevos
    private bool isGrunded = true ;
    private bool isMoving = false; //* 
    // * limite de movimiento
    private bool isRolling = false; //*
    private bool isActive = false; //****nueva
    /// <summary>
    /// Cambios en el personaje
    /// </summary>
//* private void Start() //*1° START
    private void Awake() 
    {   //**** agregando nuevo para el personaje
    //* characterAnimator.Play(characterData.runAnimationName, 0, 0f);
        characterRigidbody = GetComponent<Rigidbody>();
    }
    public void StartGame() //* Nueva Agregada
    {
        isRolling= false;
        isMoving = false;
        isActive = true;                //*cambio
        characterAnimator.Play(characterData.runAnimationName, 0, 0f);
        transform.position = characterStartPivot.position;
    }
    /// <summary>
    ///  Nueva  para el personaje
    /// </summary>
    public void Lose()
    {   //* YA DEJA DE ESCRIBIR CODIGOS
       isActive = false;
        StopAllCoroutines();
        characterAnimator.Play(characterData.loseAnimationName, 0, 0f);
    }
    /// <summary>
    ///  
    /// </summary>
    public void Jump() //*2° JUMP
    {
        if (!isActive) return; //* Nueva
        if (isGrunded)
        {   //* nueva y desechada           //* Cambiar
        //* characterAnimator.Play(characterData.jumpAnimationName, 0, 0f);
            onJump?.Invoke(); //* nueva sonido
            characterAnimator.Play(characterData.runAnimationName, 0, 0f);
            characterRigidbody.AddForce(Vector3.up * jumForce, ForceMode.Impulse);
            isGrunded = false;
        }
    }
    /// <summary>
    ///  Nuevas
    /// </summary>
    public void MoveDow() //*3° MOVE DOWN
    {   //* FUCK FUCK FUCK
        if (!isActive || isRolling) return; //*
        if (!isGrunded)
        {
            characterRigidbody.AddForce(Vector3.up * jumForce * 2, ForceMode.Impulse);
        } // *Nueva
        characterAnimator.Play(characterData.rollAnimationName, 0, 0f);
        onRoll?.Invoke(); //* Nueva Sonido
        isRolling = true; //* Mover limites
        StartCoroutine(ResetRoll()); // * mover limites
    }
    public void MoveLeft() ////*4° MOVE LEFT
    {
        //if (transform.position.x <= -distanceToMove) return;
       Move(Vector3.left);
       // *transform.position += Vector3.left * distanceToMove; 
    }
    public void MoveRight()
    {   //* limites de movimientos
        
        Move(Vector3.right);
        // *transform.position += Vector3.right * distanceToMove; 
    }   // * la mas nueva que hay
    private void Move(Vector3 direction)
    {
    //* if (isMoving) return;
        if (isMoving || !isActive) return;
        onMoveToSide?.Invoke(); //* Nueva Sonido
        //* 
        characterAnimator.Play(characterData.MoveAnimationName, 0, 0f);
        isMoving = true;
        Vector3 targetPosition = transform.position + direction * distanceToMove;
                //* no se si es el "DO" o "Do"
        transform.DOMove(targetPosition, moveDuration).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            isMoving = false;
        });
    }
    // * Bajada
    /// <summary>
    /// una nueva entera
    /// </summary>
    /// <param name="IEnumerator"></param>
    private IEnumerator ResetRoll()
    {
        yield return new WaitForSeconds(characterAnimator.GetCurrentAnimatorStateInfo(0).length);
        isRolling = false;
    }
    // *  Esta siempre abajo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrunded = true;
        }
    }
}

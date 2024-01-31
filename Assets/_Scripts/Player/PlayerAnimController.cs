using UnityEngine;

namespace Player
{
    enum PlayerAnimStates
    {
        Run, Idle, Die, Jump
    }

    [RequireComponent(typeof(Animator))]
    class PlayerAnimationController : MonoBehaviour
    {
        public static AnimationController Instance;
        [SerializeField] private Animator animator;
        void Awake()
        {
            animator = GetComponent<Animator>();
            Instance = new AnimationController(animator);
        }
        public void ChangeCurrentState(PlayerAnimStates nextState)
        {
            string state = nextState.ToString();
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(state)) return;
            animator.Play(state);
        }
    }
}
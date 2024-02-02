using Unity;
using UnityEngine;

namespace AI
{
    enum AIAnimStates
    {
        Run, Idle, Die, Jump, Hit, Attack
    }

    [RequireComponent(typeof(Animator))]
    class AIAnimController : MonoBehaviour
    {
        public static AnimationController Instance;
        [SerializeField] private Animator animator;
        void Awake()
        {
            animator = GetComponent<Animator>();
            Instance = new AnimationController(animator);
        }
        public void ChangeCurrentState(AIAnimStates nextState)
        {
            string state = nextState.ToString();
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(state)) return;
            animator.Play(state);
        }
    }
}
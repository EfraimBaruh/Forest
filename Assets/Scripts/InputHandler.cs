using System;
using UnityEngine;

namespace CommandPattern
{
    [RequireComponent(typeof(Transform))]
    public class InputHandler : MonoBehaviour
    {
        [Range(0.01f, 0.1f)]
        public float MoveSpeed;
        [Range(0.01f, 2f)]
        public float RotateSpeed;

        [SerializeField]
        private KeyCode _forward;
        [SerializeField]
        private KeyCode _backward;
        [SerializeField]
        private KeyCode _left;
        [SerializeField]
        private KeyCode _right;

        private Transform _objTransform = null;

        //The commands we use
        private Command _moveForward;
        private Command _moveBackward;
        private Command _moveLeft;
        private Command _moveRight;
        private Command _rotateHorizontal;
        private Command _rotateVertical;

        private float _previousMoveSpeed;
        private float _previousRotateSpeed;

        private void Awake()
        {
            _objTransform = GetComponent<Transform>();
        }

        private void Start()
        {
            // initialize previous values
            _previousMoveSpeed = MoveSpeed;
            _previousRotateSpeed = RotateSpeed;

            //initiate commands
            _moveForward = new MoveForward(MoveSpeed);
            _moveBackward = new MoveBackward(MoveSpeed);
            _moveLeft = new MoveLeft(MoveSpeed);
            _moveRight = new MoveRight(MoveSpeed);
            _rotateHorizontal = new RotateHorizontal(RotateSpeed);
            _rotateVertical = new RotateVertical(RotateSpeed);

        }

        private void Update()
        {
            if (Input.anyKey)
            {
                HandleInput();
            }

            // on mouse move in horizontal axis
            if (Mathf.Abs(Input.GetAxis("Mouse X")) > 0)
            {
                _rotateHorizontal.Execute(_objTransform);
            }

            // on mouse move in vertical axis
            if (Mathf.Abs(Input.GetAxis("Mouse Y")) > 0)
            {
                _rotateVertical.Execute(_objTransform);
            }

#if UNITY_EDITOR
            // Control for inspector updates
            if (MoveSpeed != _previousMoveSpeed) 
            {
                UpdateMoveSpeed();
            }
            if (RotateSpeed != _previousRotateSpeed)
            {
                UpdateRotateSpeed();
            }
#endif
        }

        //Check if key is pressed, if so execute what key is binded to
        private void HandleInput()
        {
            // Handle nullable exception
            if(_objTransform == null)
            {
                throw new Exception("Transform for InputHandler.cs not assigned");
            }

            if (Input.GetKey(_forward))
            {
                _moveForward.Execute(_objTransform);
            }

            if (Input.GetKey(_backward))
            {
                _moveBackward.Execute(_objTransform);
            }

            if (Input.GetKey(_left))
            {
                _moveLeft.Execute(_objTransform);
            }

            if (Input.GetKey(_right))
            {
                _moveRight.Execute(_objTransform);
            }
        }

        // Update speed in all move commands at runtime
        private void UpdateMoveSpeed()
        {
            _moveForward.UpdateSpeed(MoveSpeed);
            _moveBackward.UpdateSpeed(MoveSpeed);
            _moveLeft.UpdateSpeed(MoveSpeed);
            _moveRight.UpdateSpeed(MoveSpeed);

            _previousMoveSpeed = MoveSpeed;
        }

        // Update speed in all rotate commands at runtime
        private void UpdateRotateSpeed()
        {
            _rotateHorizontal.UpdateSpeed(RotateSpeed);

            _previousRotateSpeed = RotateSpeed;
        }
    }
}

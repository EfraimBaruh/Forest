using UnityEngine;

namespace CommandPattern
{
    //The parent class
    public abstract class Command
    {
        //Speed of command execution
        public float Speed = 1f;

        public Command () {}

        public Command(float speed) 
        {
            Speed = speed;
        }

        //Execute command, for extension and overloading purposes
        public abstract void Execute(Transform objTransform);

        //Undo command
        public virtual void Undo(Transform objTransform) { }

        //Move command
        protected virtual void Move(Transform objTransform, Vector3 direction) 
        {
            objTransform.position += direction * Speed;
        }

        protected virtual void Rotate(Transform objTransform, Vector3 angles) 
        {
            objTransform.localEulerAngles = angles;
        }

        //Update speed on runtime
        public void UpdateSpeed(float speed)
        {
            Speed = speed;
        }
    }

}

using UnityEngine;

namespace CommandPattern
{
    public class MoveForward : Command
    {
        private static Vector3 _movementSurface = Vector3.up;
        public MoveForward(float speed) : base(speed) { }

        //Called when we press a key
        public override void Execute(Transform objTransform)
        {
            Vector3 direction = Vector3.ProjectOnPlane(objTransform.forward, _movementSurface);

            //Move the object
            Move(objTransform, direction);
        }

    }
}


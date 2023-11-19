using UnityEngine;

namespace CommandPattern
{
    public class MoveBackward : Command
    {
        private static Vector3 _movementSurface = Vector3.up;

        public MoveBackward(float speed) : base(speed) { }

        //Called when we get input
        public override void Execute(Transform objTransform)
        {
            Vector3 direction = Vector3.ProjectOnPlane(-objTransform.forward, _movementSurface);

            //Move the object
            Move(objTransform, direction);
        }

    }
}


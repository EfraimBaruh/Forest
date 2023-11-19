using UnityEngine;

namespace CommandPattern
{
    public class MoveLeft : Command
    {
        private static Vector3 _movementSurface = Vector3.up;

        public MoveLeft(float speed) : base(speed) { }

        //Called when we press a key
        public override void Execute(Transform objTransform)
        {
            Vector3 direction = Vector3.ProjectOnPlane(-objTransform.right, _movementSurface);

            //Move the object
            Move(objTransform, direction);
        }

    }
}


using UnityEngine;

namespace CommandPattern
{
    public class RotateHorizontal : Command
    {
        private float yaw = 0.0f;

        public RotateHorizontal(float speed) : base(speed) { }

        public override void Execute(Transform objTransform)
        {
            float pitch = objTransform.localEulerAngles.x;
            yaw += Speed * Input.GetAxis("Mouse X");

            Rotate(objTransform, new Vector3(pitch, yaw, 0.0f));
        }
    }
}

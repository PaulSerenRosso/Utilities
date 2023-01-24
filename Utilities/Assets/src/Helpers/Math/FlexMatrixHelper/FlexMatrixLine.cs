using System;

namespace HelperPSR.Math.FlexMatrixes
{
    [Serializable]
    public struct FlexMatrixLine
    {
        public FlexMatrixLine(float[] values = null)
        {
            Values = values;
        }

        public FlexMatrixLine(int count)
        {
            Values = new float[count];
        }

        public float[] Values;
    }
}
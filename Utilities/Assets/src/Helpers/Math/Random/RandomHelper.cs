using UnityEngine;

namespace HelperPSR.Randoms
{


    static public class RandomHelper
    {
        public static int PickRandomElementIndex(int[] probabilities)
        {
            int randomMax = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                randomMax += probabilities[i];
            }
            int rand = Random.Range(0, randomMax);
            int index = 0;
            while (true)
            {
                rand -= probabilities[index];
                if (rand <= 0)
                {
                    break;
                }
                if (index == probabilities.Length-1)
                {
                    break;
                }
                index++;
            }

            return index;
        }
    }
}

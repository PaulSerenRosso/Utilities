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

            int currentElement;
            int rand = Random.Range(0, randomMax);
            //Debug.Log("rate : " + rate);
            int index = 0;
            while (rand >= 0)
            {
                currentElement = probabilities[index];
                rand -= probabilities[index];
                index++;
                if (index == probabilities.Length)
                {
                    break;
                }
            }

            return index;
        }
    }
}

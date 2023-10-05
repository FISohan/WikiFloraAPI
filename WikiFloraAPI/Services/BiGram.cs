using System.Text;

namespace WikiFloraAPI.Services
{
    public class BiGram
    {
        private static List<byte[]> wordLetterPair(string str)
        {
            byte[] strByte = Encoding.UTF8.GetBytes(str);
            List<byte[]> result = new List<byte[]>();
            int strLen = strByte.Length;
            for (int i = 0; i < strLen - 1; i++)
            {
                byte[] pair = new byte[2] { strByte[i], strByte[i + 1] };
                result.Add(pair);
            }
            return result;
        }

        public static double similarity(string str1, string str2)
        {
            List<byte[]> str1WordLetterPair = wordLetterPair(str1);
            List<byte[]> str2WordLetterPair = wordLetterPair(str2);
            int pairIntersection = 0;
            int pairUnion = str1WordLetterPair.Count + str2WordLetterPair.Count;
            for (int i = 0; i < str1WordLetterPair.Count; i++)
            {
                byte[] pair1 = str1WordLetterPair[i];
                for (int j = 0; j < str2WordLetterPair.Count; j++)
                {
                    byte[] pair2 = str2WordLetterPair[j];
                    if ((pair1[0] == pair2[0]) && (pair1[1] == pair2[1]))
                    {
                        pairIntersection++;
                        str2WordLetterPair.RemoveAt(j);
                        break;
                    }
                }
            }
            double ans = ((2D * pairIntersection) / pairUnion);
            return ans;
        }

    }
}

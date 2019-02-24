namespace CodingKatas
{
    public class BinarySearchKata
    {
        public int Search(int searchTerm, int[] v, int length)
        {
            int low, high, mid;

            low = 0;
            high = length - 1;
            mid = (low + high) / 2;

            while (low <= high && searchTerm != v[mid])
            {
                if (searchTerm < v[mid])
                    high = mid - 1;
                else
                    low = mid + 1;
                mid = (low + high) / 2;
            }
            if (searchTerm == v[mid])
                return mid;
            else
                return -1;
        }
    }
}

public class Xbonacci
{
    private double[] cache;
    private int signatureLength;

    public double[] Tribonacci(double[] signature, int n)
    {
        cache = new double[n];
        signatureLength = signature.Length;
        PopulateSignatureCache(signature);
        CalculateSequence(n - 1);
        return cache;
    }

    private void PopulateSignatureCache(double[] signature)
    {
        for (int i = 0; i < signature.Length && i < cache.Length; i++)
        {
            if (i > cache.Length)
                return;
            cache[i] = signature[i];
        }
    }

    private double CalculateSequence(int n)
    {
        if (n < 0)
            return 0;

        if (cache[n] == 0 && n >= signatureLength)
            cache[n] = CalculateSequence(n - 1) + CalculateSequence(n - 2) + CalculateSequence(n - 3);

        return cache[n];
    }
}

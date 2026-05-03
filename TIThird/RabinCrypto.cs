using System;
using System.Collections.Generic;
using System.Numerics;

namespace TIThird
{
    public class RabinCipher
    {
        private BigInteger p, q, n, b;
        private BigInteger yp, yq;

        public void SetParameters(BigInteger p, BigInteger q, BigInteger b)
        {
            this.p = p;
            this.q = q;
            this.b = b;
            this.n = p * q;
            ExtendedEuclid(p, q, out BigInteger yp, out BigInteger yq);
            this.yp = yp;
            this.yq = yq;
        }

        public BigInteger GetN() => n;

        public BigInteger EncryptByte(byte m)
        {
            BigInteger mBig = m;
            BigInteger c = (mBig * (mBig + b)) % n;
            if (c < 0) c += n;
            return c;
        }

        public List<BigInteger> Encrypt(byte[] data)
        {
            List<BigInteger> result = new List<BigInteger>();
            foreach (byte m in data)
            {
                result.Add(EncryptByte(m));
            }
            return result;
        }

        public byte[] Decrypt(BigInteger[] ciphertexts)
        {
            List<byte> result = new List<byte>();
            foreach (BigInteger c in ciphertexts)
            {
                byte? m = DecryptSingle(c);
                if (m.HasValue)
                    result.Add(m.Value);
                else
                    throw new Exception($"Не удалось расшифровать значение: {c}");
            }
            return result.ToArray();
        }

        private byte? DecryptSingle(BigInteger c)
        {
            BigInteger D = (b * b + 4 * c) % n;
            if (D < 0) D += n;

            BigInteger sqrtD_p = ModPow(D, (p + 1) / 4, p);
            BigInteger sqrtD_q = ModPow(D, (q + 1) / 4, q);

            BigInteger r1 = (yp * p * sqrtD_q + yq * q * sqrtD_p) % n;
            if (r1 < 0) r1 += n;

            BigInteger r2 = n - r1;
            if (r2 < 0) r2 += n;

            BigInteger r3 = (yp * p * sqrtD_q - yq * q * sqrtD_p) % n;
            if (r3 < 0) r3 += n;

            BigInteger r4 = n - r3;
            if (r4 < 0) r4 += n;

            List<BigInteger> roots = new List<BigInteger> { r1, r2, r3, r4 };

            foreach (BigInteger r in roots)
            {
                BigInteger m = RecoverMessage(r);
                if (m >= 0 && m <= 255)
                {
                    return (byte)m;
                }
            }

            return null;
        }

        private BigInteger RecoverMessage(BigInteger r)
        {
            BigInteger numerator;
            if ((r - b) % 2 == 0)
            {
                numerator = (-b + r) / 2;
            }
            else
            {
                numerator = (-b + n + r) / 2;
            }

            BigInteger m = numerator % n;
            if (m < 0) m += n;
            return m;
        }

        private void ExtendedEuclid(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return;
            }
            ExtendedEuclid(b, a % b, out BigInteger x1, out BigInteger y1);
            x = y1;
            y = x1 - (a / b) * y1;
        }

        private BigInteger ModPow(BigInteger a, BigInteger z, BigInteger n)
        {
            BigInteger result = 1;
            a = a % n;
            while (z > 0)
            {
                if (z % 2 == 1)
                    result = (result * a) % n;
                a = (a * a) % n;
                z = z / 2;
            }
            return result;
        }

        public static bool CheckPQCondition(BigInteger p, BigInteger q)
        {
            return (p % 4 == 3) && (q % 4 == 3);
        }

        public static bool IsPrime(BigInteger n)
        {
            if (n < 2) return false;
            if (n == 2 || n == 3) return true;
            if (n % 2 == 0) return false;

            for (BigInteger i = 3; i * i <= n; i += 2)
                if (n % i == 0) return false;
            return true;
        }
    }
}
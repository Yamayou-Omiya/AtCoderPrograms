using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace MyLib {

    public class Read {

        public static int OneInt() {
            return Convert.ToInt32(Console.ReadLine());
        }

        public static long OneLong() {
            return Convert.ToInt64(Console.ReadLine());
        }

        public static double OneDouble() {
            return Convert.ToDouble(Console.ReadLine());
        }

        public static int[] ManyInt() {
            return Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
        }

        public static long[] ManyLong() {
            return Console.ReadLine().Split(' ').Select(s => Convert.ToInt64(s)).ToArray();
        }

        public static double[] ManyDouble() {
            return Console.ReadLine().Split(' ').Select(s => Convert.ToDouble(s)).ToArray();
        }

        public static (int, int) TwoInt() {
            int[] tmp = ManyInt();
            return (tmp[0], tmp[1]);
        }

        public static (long, long) TwoLong() {
            long[] tmp = ManyLong();
            return (tmp[0], tmp[1]);
        }

        public static (int, int, int) ThreeInt() {
            int[] tmp = ManyInt();
            return (tmp[0], tmp[1], tmp[2]);
        }

        public static (long, long, long) ThreeLong() {
            long[] tmp = ManyLong();
            return (tmp[0], tmp[1], tmp[2]);
        }

        public static (int, int, int, int) FourInt() {
            int[] tmp = ManyInt();
            return (tmp[0], tmp[1], tmp[2], tmp[3]);
        }

        public static (long, long, long, long) FourLong() {
            long[] tmp = ManyLong();
            return (tmp[0], tmp[1], tmp[2], tmp[3]);
        }
    }

    public class Math {

        public static long nCr(long n, long r) {

            long ret = 1;

            for (int i = 1; i <= r; i++) {
                ret = ret * (n - i + 1) / i;
            }

            return ret;
        }

        public static long GCD(long a, long b) {
            if (b == 0) {
                return a;
            }
            else {
                return GCD(b, a % b);
            }
        }

        public static long LCM(long a, long b) {
            return a / GCD(a, b) * b;
        }

        public static (List<long> primes, long?[] lowestPrimeFactors) EnumeratePrimesAndLowestPrimeFactors(long N) {

            List<long> primes = new List<long>();
            long?[] lowestPrimeFactors = new long?[N + 1];
            Array.Fill(lowestPrimeFactors, null);

            for (long i = 2; i <= N; i++) {

                if (lowestPrimeFactors[i] is null) {
                    lowestPrimeFactors[i] = i;
                    primes.Add(i);
                }

                foreach (long p in primes) {

                    if (p * i > N || p > lowestPrimeFactors[i]) {
                        break;
                    }

                    lowestPrimeFactors[p * i] = p;
                }
            }

            return (primes, lowestPrimeFactors);
        }

        public static List<long> EnumeratePrimes(long N) {

            (List<long> primes, _) = EnumeratePrimesAndLowestPrimeFactors(N);

            return primes;
        }

        public static long?[] EnumerateLowestPrimeFactors(long N) {

            (_, long?[] lowestPrimeFactors) = EnumeratePrimesAndLowestPrimeFactors(N);

            return lowestPrimeFactors;
        }

        /// <remarks>
        /// lowestPrimeFactors は N + 1 以上の要素数を持つ必要があります．
        /// </remarks>
        public static List<long> EnumeratePrimeFactors(long N, long?[] lowestPrimeFactors) {

            List<long> primeFactors = new List<long>();

            while (N > 1) {

                long tmpPrimeFactor = (long)lowestPrimeFactors[N];

                primeFactors.Add(tmpPrimeFactor);

                N /= tmpPrimeFactor;
            }

            return primeFactors;
        }
    }

    namespace Graph {

        namespace Undirected {

            /// <summary>
            /// 無向グラフの (等コストな) 連結リスト
            /// </summary>
            public class ConnectionList {

                private Dictionary<int, List<int>> e = new Dictionary<int, List<int>>();

                /// <summary>
                /// a と b にエッジを張る
                /// </summary>
                public void Connect(int a, int b) {

                    if (!e.ContainsKey(a)) {
                        e.Add(a, new List<int>());
                    }

                    if (!e.ContainsKey(b)) {
                        e.Add(b, new List<int>());
                    }

                    e[a].Add(b);
                    e[b].Add(a);
                }

                public List<int> GetConnection(int nodeId) {

                    if (e.ContainsKey(nodeId)) {
                        return new List<int>(this.e[nodeId]);
                    }

                    return new List<int>();
                }

                public bool IsConnect(int a, int b) {

                    if (this.e.ContainsKey(a)) {
                        return this.e[a].Contains(b);
                    }

                    return false;
                }

                public int GetEdgeNum(int nodeId) {

                    if (this.e.ContainsKey(nodeId)) {
                        return this.e[nodeId].Count;
                    }

                    return 0;
                }
            }
        }
    }

    public class UnionFind<T> {

        public T Value { get; set; }
        public UnionFind<T> Parent { get; set; }
        public int Count { get; set; }

        public UnionFind(T value) {
            this.Value = value;
            this.Parent = this;
            this.Count = 1;
        }

        public UnionFind<T> Root {
            get {

                if (this.Parent != this) {
                    this.Parent = this.Parent.Root;
                }

                return this.Parent;
            }
        }

        /// <summary>
        /// 同じユニオンか確認
        /// </summary>
        public bool IsSame(UnionFind<T> N) {
            return Object.ReferenceEquals(this.Root, N.Root);
        }

        public void Unite(UnionFind<T> N) {
            N.Root.Count += this.Root.Count;
            this.Root.Parent = N.Root;
        }
    }

    public class BitSet {

        private readonly int bitCount;
        private BigInteger value;

        public BitSet(int bitCount) {
            this.bitCount = bitCount;
            this.value = 0;
        }

        public BitSet(int bitCount, BigInteger value) {
            this.bitCount = bitCount;
            this.value = value;
        }

        /// <summary>
        /// 2進数表記の文字列から生成
        /// </summary>
        /// <remarks>
        /// 文字列桁が少ない場合，文字列部を右詰めし，左の不足部分は0埋め<br/>
        /// 例 : BitSet(5, "10") -> 00010
        /// </remarks>
        public BitSet(int bitCount, string value = "0") {
            if (bitCount < value.Length) {
                throw new Exception("BitSet");
            }
            this.bitCount = bitCount;
            this.value = 0;
            for (int i = 0; i < value.Length; i++) {
                this.value <<= 1;
                this.value += int.Parse(value[i].ToString());
            }
            this.value = BigInteger.Parse(value);
        }

        public int Bit(int idx) {
            return (int)((this.value >> (this.bitCount - idx - 1)) % 2);
        }

        /// <summary>
        /// すべてのビットを 1 にする
        /// </summary>
        public void Set() {
            this.value = ((BigInteger)1 << this.bitCount) - 1;
        }

        /// <summary>
        /// 指定した位置のビットを 1 にする
        /// </summary>
        /// <param name="idx">1 にするビットインデックス</param>
        public void Set(int idx) {
            this.value |= ((BigInteger)1 << (this.bitCount - idx - 1));
        }

        public void Reset() {
            this.value = 0;
        }

        public void Reset(int idx) {
            BigInteger tmp = ((BigInteger)1 << (this.bitCount - idx - 1));
            this.value -= (this.value & tmp);
        }

        public void Flip() {
            this.value ^= (((BigInteger)1 << this.bitCount) - 1);
        }

        public void Flip(int idx) {
            BigInteger tmp = ((BigInteger)1 << (this.bitCount - idx - 1));
            this.value ^= tmp;
        }

        public bool Test(int idx) {
            BigInteger tmp = ((BigInteger)1 << (this.bitCount - idx - 1));
            return (this.value & tmp) != 0;
        }

        public override string ToString() {
            string tmp = "";
            BigInteger tmpValue = this.value;
            while (tmpValue != 0) {
                tmp = (tmpValue % 2).ToString() + tmp;
            }
            int remain = this.bitCount - tmp.Length;
            for (int i = 0; i < remain; i++) {
                tmp = "0" + tmp;
            }
            return tmp;
        }

        public static BitSet operator ~(BitSet bitSet) {
            BitSet ans = new BitSet(bitSet.BitCount);
            ans.value = bitSet.value ^ (((BigInteger)1 << bitSet.BitCount) - 1);
            return ans;
        }

        public static BitSet operator &(BitSet left, BitSet right) {
            BitSet ans = new BitSet(left.BitCount);
            ans.value = left.value & right.value;
            return ans;
        }

        public static BitSet operator |(BitSet left, BitSet right) {
            BitSet ans = new BitSet(left.BitCount);
            ans.value = left.value | right.value;
            return ans;
        }

        public static BitSet operator ^(BitSet left, BitSet right) {
            BitSet ans = new BitSet(left.BitCount);
            ans.value = left.value ^ right.value;
            return ans;
        }

        public static BitSet operator <<(BitSet value, int shift) {
            BitSet ans = new BitSet(value.BitCount);
            ans.value = (value.value << shift) & (((BigInteger)1 << value.BitCount) - 1);
            return ans;
        }

        public static BitSet operator >>(BitSet value, int shift) {
            BitSet ans = new BitSet(value.BitCount);
            ans.value = value.value >> shift;
            return ans;
        }

        public int BitCount => this.bitCount;
        public BigInteger PopCount => BigInteger.PopCount(this.value);
        public bool None => this.value == 0;
        public bool All {
            get {
                BigInteger all = ((BigInteger)1 << this.bitCount) - 1;
                return all == (all & this.value);
            }
        }
        public bool Any => this.value != 0;
        public BigInteger Value => this.value;
    }

    public class Pair<T> {

        private (T F, T S) pair;

        public Pair(T first, T second) {
            this.pair = (F: first, S: second);
        }

        public T First {
            get => this.pair.F;
            set => this.pair.F = value;
        }
        public T Second {
            get => this.pair.S;
            set => this.pair.S = value;
        }
    }

    public class SegTree<T> {

        private T value;
        private readonly long leftLimit;
        private readonly long mid;
        private readonly long rightLimit;
        private readonly bool isLeaf;
        private SegTree<T>? leftSeg;
        private SegTree<T>? rightSeg;
        private readonly Func<T, T, T> op;

        public SegTree(long left, long right, T e, Func<T, T, T> op) {

            this.op = op;
            this.isLeaf = (left == right - 1);
            this.leftLimit = left;
            this.mid = (left + right) / 2;
            this.rightLimit = right;

            if (this.isLeaf) {
                this.value = e;
            }
            else {
                this.leftSeg = new SegTree<T>(left, mid, e, op);
                this.rightSeg = new SegTree<T>(mid, right, e, op);
                this.value = this.op(this.leftSeg.Value, this.rightSeg.Value);
            }
        }

        public void Set(long left, long right, T value) {

            if (left >= right) {
                return;
            }

            if (this.isLeaf) {
                this.value = value;
            }
            else {

                Debug.Assert(this.leftSeg is not null && this.rightSeg is not null);

                if (this.mid <= left) {
                    this.rightSeg.Set(left, right, value);
                    this.value = this.op(this.leftSeg.Value, this.rightSeg.Value);
                }
                else if (right <= this.mid) {
                    this.leftSeg.Set(left, right, value);
                    this.value = this.op(this.leftSeg.Value, this.rightSeg.Value);
                }
                else {
                    this.leftSeg.Set(left, this.mid, value);
                    this.rightSeg.Set(this.mid, right, value);
                    this.value = this.op(this.leftSeg.Value, this.rightSeg.Value);
                }
            }
        }

        public T Prod(long left, long right) {

            if (this.leftLimit == left && this.rightLimit == right) {
                return this.value;
            }

            Debug.Assert(this.leftSeg is not null && this.rightSeg is not null);

            if (this.mid <= left) {
                return this.rightSeg.Prod(left, right);
            }
            else if (right <= this.mid) {
                return this.leftSeg.Prod(left, right);
            }
            else {
                return this.op(this.leftSeg.Prod(left, this.mid), this.rightSeg.Prod(this.mid, right));
            }
        }

        public T Value => this.value;
    }

    public class Search {

        /// <summary>
        /// ビット全探索を簡素化
        /// </summary>
        /// <param name="N">対象の数</param>
        /// <param name="action">ある組合せにおいて，各対象に行う操作．<br/>
        /// i, j => {} の形式で記述した場合，i は組合せを表す 2 進数，j は対象のインデックス
        /// </param>
        public static void BBFEach(int N, Action<int, int> action) {
            for (int i = 0; i < 1 << N; i++) {
                int target = i;
                while (target != 0) {
                    int j = target.GetLeastSetBitIdx();
                    action(i, j);
                    target = target.NextBit();
                }
            }
        }

        /// <summary>
        /// ビット全探索における組合せ列挙ループを簡素化
        /// </summary>
        /// <param name="N">対象の数</param>
        /// <param name="action">各組合せに対して行う操作．i => {} の形式で記述すれば i のビット表記が組合せ</param>
        public static void BBFLoop(int N, Action<int> action) {
            for (int i = 0; i < 1 << N; i++) {
                action(i);
            }
        }

        /// <summary>
        /// ビット全探索において，組合せが与えられた後の処理を簡素化
        /// </summary>
        /// <param name="N">対象の組合せをビットで表した数値</param>
        /// <param name="action">各対象に対する操作</param>
        public static void BBFTarget(int N, Action<int> action) {
            while (N != 0) {
                action(N.GetLeastSetBitIdx());
                N = N.NextBit();
            }
        }

        public static int Str2Bits(string str, char flagChar) {

            int bits = 0;

            for (int i = 0; i < str.Length; i++) {
                bits <<= 1;
                if (str[i] == flagChar) {
                    bits += 1;
                }
            }

            return bits;
        }

        /// <summary>
        /// N bit の，全桁 1 の数値を返す
        /// </summary>
        public static int AllSetBits(int N) {
            return (1 << N) - 1;
        }
    }
}

public static class Extensions {

    public static void Swap<T>(this List<T> list, int i, int j) {
        (list[j], list[i]) = (list[i], list[j]);
    }

    public static void ReverseSort<T>(this List<T> list) where T : IComparable {
        list.Sort((a, b) => b.CompareTo(a));
    }

    /// <summary>
    /// 二分探索 (結果が複数ならその最小インデックス)
    /// </summary>
    /// <remarks>
    /// リストは昇順にソート済である必要があります
    /// </remarks>
    public static (bool, int) LowerBound<T>(this List<T> list, T target) where T : INumber<T> {

        int idx = list.BinarySearch(target);

        if (idx >= 0) {
            while (idx > 0 && list[idx - 1] == list[idx]) {
                idx--;
            }
        }
        else {
            idx = ~idx;
        }

        return (0 <= idx && idx < list.Count, idx);
    }

    /// <summary>
    /// 二分探索 (結果が複数ならその最小インデックス)
    /// </summary>
    /// <remarks>
    /// リストは昇順にソート済である必要があります
    /// </remarks>
    public static (bool, int) LowerBound(this List<string> list, string target) {

        int idx = list.BinarySearch(target);

        if (idx >= 0) {
            while (idx > 0 && list[idx - 1] == list[idx]) {
                idx--;
            }
        }
        else {
            idx = ~idx;
        }

        return (0 <= idx && idx < list.Count, idx);
    }

    public static void WriteLine(this BitArray array) {
        foreach (var bit in array) {
            Console.Write((bool)bit ? 1 : 0);
        }
        Console.WriteLine();
    }

    public static bool IsPrime(this int n) {

        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        double sqrtN = Math.Sqrt(n);
        for (long i = 3; i <= sqrtN; i += 2) {
            if (n % i == 0) {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 値の2進数表記中で最も右側にある1のみを抽出して返します。<br/>
    /// 例えば，6は110なので最も右側の1は真ん中であり、返るのは010、つまり2です
    /// </summary>
    public static int GetLeastSetBit(this int N) {
        return N & (-N);
    }

    /// <summary>
    /// 値の2進数表記中で最も右側にある1のみを抽出して返します．<br/>
    /// 例えば，6は110なので最も右側の1は真ん中であり，返るのは010，つまり2です
    /// </summary>
    public static long GetLeastSetBit(this long N) {
        return N & (-N);
    }

    /// <summary>
    /// 値の2進数表記中で最も右側にある1のみを抽出して返します．<br/>
    /// 例えば，6は110なので最も右側の1は真ん中であり，返るのは010，つまり2です
    /// </summary>
    public static BigInteger GetLeastSetBit(this BigInteger N) {
        return N & (-N);
    }

    /// <summary>
    /// 値の2進数表記中で最も右側にある1が何ビット目かを返します．<br/>
    /// 例えば，6は110なので最も右側の1は真ん中であり，返るのはそのインデックスである1です
    /// </summary>
    public static int GetLeastSetBitIdx(this int N) {
        return BitOperations.Log2((uint)(N & (-N)));
    }

    /// <summary>
    /// 値の2進数表記中で最も右側にある1が何ビット目かを返します．<br/>
    /// 例えば，6は110なので最も右側の1は真ん中であり，返るのはそのインデックスである1です
    /// </summary>
    public static long GetLeastSetBitIdx(this long N) {
        return BitOperations.Log2((ulong)(N & (-N)));
    }

    /// <summary>
    /// 値の2進数表記中で最も右側にある1が何ビット目かを返します．<br/>
    /// 例えば，6は110なので最も右側の1は真ん中であり，返るのはそのインデックスである1です
    /// </summary>
    public static BigInteger GetLeastSetBitIdx(this BigInteger N) {
        return BigInteger.Log2(N);
    }

    /// <summary>
    /// 値の2進表記中で最も右側にある1を反転させる．<br/>
    /// 例えば，6は110なので最も右側の1は真ん中であり，返るのは100，つまり4です．
    /// </summary>
    public static int NextBit(this int N) {
        return N ^ (N & (-N));
    }

    /// <summary>
    /// 値の2進表記中で最も右側にある1を反転させる．<br/>
    /// 例えば，6は110なので最も右側の1は真ん中であり，返るのは100，つまり4です．
    /// </summary>
    public static long NextBit(this long N) {
        return N ^ (N & (-N));
    }

    /// <summary>
    /// 値の2進表記中で最も右側にある1を反転させる．<br/>
    /// 例えば，6は110なので最も右側の1は真ん中であり，返るのは100，つまり4です．
    /// </summary>
    public static BigInteger NextBit(this BigInteger N) {
        return N ^ (N & (-N));
    }

    public static int PopCount(this int N) {
        return BitOperations.PopCount((uint)N);
    }

    public static int PopCount(this long N) {
        return BitOperations.PopCount((ulong)N);
    }
}


public class Program {

    public static void Main(string[] args) {

        (int N, int T) = MyLib.Read.TwoInt();
        string S = Console.ReadLine();
        long[] X = MyLib.Read.ManyLong();

        List<long> moveS = new List<long>();
        List<long> moveE = new List<long>();
        List<long> nomove = new List<long>();

        for(int i = 0; i < N; i++) {
            if (S[i] == '0') {
                nomove.Add(X[i]);
            }
            else {
                moveS.Add(X[i]);
                moveE.Add(X[i] + T * 2);
            }
        }

        nomove.Sort();
        moveS.Sort();
        moveE.Sort();

        int sidx = 0;
        int eidx = 0;
        long ans = 0;
        long w = 0;
        foreach(long n in nomove) {
            while (sidx < moveS.Count && moveS[sidx] < n) {
                sidx++;
                w++;
            }
            while (eidx < moveE.Count && moveE[eidx] < n) {
                eidx++;
                w--;
            }
            ans += w;
        }

        Console.WriteLine(ans);
    }
}

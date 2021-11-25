using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;




namespace cslabs
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    class TestCollections<TKey, TValue>
    {

        List<TKey> keys;
        List<string> strings;
        Dictionary<TKey, TValue> keyValues;
        Dictionary<string, TValue> stringValues;
        GenerateElement<TKey, TValue> gen;

        public TestCollections(int value, GenerateElement<TKey, TValue> generator)
        {
            this.keys = new List<TKey>(value);
            this.gen = generator;
            this.strings = new List<string>(value);
            this.keyValues = new Dictionary<TKey, TValue>(value);
            this.stringValues = new Dictionary<string, TValue>(value);
            for (int i = 0; i < value; i++)
            {
                KeyValuePair<TKey, TValue> pair = gen(i);

                string s = RandomString(10);
                this.keys.Add(pair.Key);
                this.strings.Add(s);
                this.keyValues.Add(pair.Key, pair.Value);
                this.stringValues.Add(s, pair.Value);
            }
        }


        public void CalcTime()
        {

            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Total count of elements in keys: " + this.keys.Count);
            sw.Start();
            this.keys.Contains(this.keys[0]);
            sw.Stop();
            Console.WriteLine("search first element in list of keys: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.keys.Contains(this.keys[this.keys.Count / 2]);
            sw.Stop();
            Console.WriteLine("search middle element in list of keys: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.keys.Contains(this.keys.Last());
            sw.Stop();
            Console.WriteLine("search last element in list of keys: " + sw.ElapsedMilliseconds);
            sw.Reset();


            Console.WriteLine("Total count of elements in strings: " + this.strings.Count);
            sw.Start();
            this.strings.Contains(this.strings[0]);
            sw.Stop();
            Console.WriteLine("search first element in list of strings: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.strings.Contains(this.strings[this.strings.Count / 2]);
            sw.Stop();
            Console.WriteLine("search middle element in list of strings: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.strings.Contains(this.strings.Last());
            sw.Stop();
            Console.WriteLine("search last element in list of strings: " + sw.ElapsedMilliseconds);
            sw.Reset();

            Console.WriteLine("Total count of key elements in key-value: " + this.keyValues.Count);
            sw.Start();
            this.keyValues.ContainsKey(this.keys[0]);
            sw.Stop();
            Console.WriteLine("search first element's key in dict of  key-value: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.keyValues.ContainsKey(this.keys[this.keys.Count / 2]);
            sw.Stop();
            Console.WriteLine("search middle element's key in dict of  key-value: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.keyValues.ContainsKey(this.keys.Last());
            sw.Stop();
            Console.WriteLine("search last element's key in dict of  key-value: " + sw.ElapsedMilliseconds);
            sw.Reset();


            sw.Start();
            this.keyValues.ContainsValue(this.keyValues[this.keys[0]]);
            sw.Stop();
            Console.WriteLine("search first element's value in dict of  key-value: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.keyValues.ContainsValue(this.keyValues[this.keys[this.keys.Count / 2]]);
            sw.Stop();
            Console.WriteLine("search middle element's value in dict of key-value: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.keyValues.ContainsValue(this.keyValues[this.keys.Last()]);
            sw.Stop();
            Console.WriteLine("search last element's value in dict of  key-value: " + sw.ElapsedMilliseconds);
            sw.Reset();

            Console.WriteLine("Total count of key elements in  string-value: " + this.stringValues.Count);
            sw.Start();
            this.stringValues.ContainsKey(this.strings[0]);
            sw.Stop();
            Console.WriteLine("search first element's key in dict of string-value: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.stringValues.ContainsKey(this.strings[this.strings.Count / 2]);
            sw.Stop();
            Console.WriteLine("search middle element's key in dict of string-value: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.stringValues.ContainsKey(this.strings.Last());
            sw.Stop();
            Console.WriteLine("search last element's key in dict of string-value: " + sw.ElapsedMilliseconds);
            sw.Reset();

            //Console.WriteLine("Total count of value elements in name-student: " + this.keys.Count);
            sw.Start();
            this.stringValues.ContainsValue(this.keyValues[this.keys[0]]);
            sw.Stop();
            Console.WriteLine("search first element's value in dict of string-value: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.stringValues.ContainsValue(this.keyValues[this.keys[this.keys.Count / 2]]);
            sw.Stop();
            Console.WriteLine("search middle element's value in dict of string-value: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.stringValues.ContainsValue(this.keyValues[this.keys.Last()]);
            sw.Stop();
            Console.WriteLine("search last element's value in dict of string-value: " + sw.ElapsedMilliseconds);
            sw.Reset();

        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}

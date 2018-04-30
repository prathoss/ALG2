using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrab
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> arraysPrescript = new Dictionary<int, int>
            {
                {10, 50000 },
                { 40, 10000 },
                { 160, 2000 },
                { 640, 200 },
                { 2560, 20 },
                { 10240, 5 }
            };
            Dictionary<int, List<int[]>> arrays = new Dictionary<int, List<int[]>>
            {
                {10, new List<int[]>() },
                { 40, new List<int[]>() },
                { 160, new List<int[]>() },
                { 640, new List<int[]>() },
                { 2560, new List<int[]>() },
                { 10240, new List<int[]>() }
            };
            foreach(KeyValuePair<int, int> pres in arraysPrescript)
            {
                for (int i = 0; i < pres.Value; i++)
                {
                    int[] array = new int[pres.Key];
                    for (int j = 0; j < pres.Key; j++)
                    {
                        array[j] = new Random().Next(0, pres.Key - 1);
                    }
                    arrays[pres.Key].Add(new int[pres.Key]);
                }
            }
            List<double> times = new List<double>();
            List<double> ratio = new List<double>();
            double time;
            Stopwatch watch = new Stopwatch();
            foreach(KeyValuePair<int, List<int[]>> arr in arrays)
            {
                times.Add(arr.Key);
                ratio.Add(arr.Key);
                watch.Reset();
                watch.Start();
                for (int i = 0; i < arr.Value.Count; i++)
                {
                    arrays[arr.Key][i].Hrabisort(1);
                }
                watch.Stop();
                time = watch.Elapsed.TotalMilliseconds / arr.Value.Count;
                times.Add(time);
                ratio.Add(time / (arr.Key * Math.Log10(arr.Key)));
                watch.Reset();
                watch.Start();
                for (int i = 0; i < arr.Value.Count; i++)
                {
                    arrays[arr.Key][i].Hrabisort(2);
                }
                watch.Stop();
                time = watch.Elapsed.TotalMilliseconds / arr.Value.Count;
                times.Add(time);
                ratio.Add(time / (arr.Key * Math.Log10(arr.Key)));
                watch.Reset();
                watch.Start();
                for (int i = 0; i < arr.Value.Count; i++)
                {
                    arrays[arr.Key][i].Hrabisort(3);
                }
                watch.Stop();
                time = watch.Elapsed.TotalMilliseconds / arr.Value.Count;
                times.Add(time);
                ratio.Add(time / (arr.Key * Math.Log10(arr.Key)));
                watch.Reset();
                watch.Start();
                for (int i = 0; i < arr.Value.Count; i++)
                {
                    arrays[arr.Key][i].InsertionSort();
                }
                watch.Stop();
                time = watch.Elapsed.TotalMilliseconds / arr.Value.Count;
                times.Add(time);
                ratio.Add(time / (arr.Key * Math.Log10(arr.Key)));
                watch.Reset();
                watch.Start();
                for (int i = 0; i < arr.Value.Count; i++)
                {
                    arrays[arr.Key][i].Quicksort();
                }
                watch.Stop();
                time = watch.Elapsed.TotalMilliseconds / arr.Value.Count;
                times.Add(time);
                ratio.Add(time / (arr.Key * Math.Log10(arr.Key)));
            }
            string[] ftimes = new string[7];
            string[] fratio = new string[7];
            ftimes[0] = "# m \t K1 \t K2 \t K3 \t insert \t quick";
            fratio[0] = ftimes[0];
            for (int i = 0; i < 6; i++)
            {
                ftimes[i + 1] = $"{times[6 * i]} \t {times[6 * i + 1]} \t {times[6 * i + 2]} \t {times[6 * i + 3]} \t {times[6 * i + 4]} \t {times[6 * i + 5]}";
                fratio[i + 1] = $"{ratio[6 * i]} \t {ratio[6 * i + 1]} \t {ratio[6 * i + 2]} \t {ratio[6 * i + 3]} \t {ratio[6 * i + 4]} \t {ratio[6 * i + 5]}";
            }
            using (System.IO.StreamWriter tfile = new System.IO.StreamWriter("times.txt"))
            {
                foreach(string line in ftimes)
                {
                    tfile.WriteLine(line);
                }
            }
            using (System.IO.StreamWriter rfile = new System.IO.StreamWriter("ratios.txt"))
            {
                foreach (string line in fratio)
                {
                    rfile.WriteLine(line);
                }
            }
        }
    }
}

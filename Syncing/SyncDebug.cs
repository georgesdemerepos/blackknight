using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            Parallel.ForEach(items, async i =>
            {
                var r = await Task.Run(() => i).ConfigureAwait(false);
                bag.Add(r);
            });
            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var threads = Enumerable.Range(0, 3)
                .Select(i => new Thread(() => {
                    foreach (var item in itemsToInitialize)
                    {
                        concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
                    }
                }))
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }


        /// <summary>
        /// New method for InitializeList
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task<List<string>> InitializeListNew(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            await Task.WhenAll(items.Select(async i =>
            {
                var r = await Task.Run(() => i).ConfigureAwait(false);
                bag.Add(r);
            }));
            return bag.ToList();
        }

        /// <summary>
        /// New method for InitializeDictionary
        /// </summary>
        /// <param name="getItem"></param>
        /// <returns></returns>
        public Dictionary<int, string> InitializeDictionaryNew(Func<int, string> getItem)
        {
            var keys = Enumerable.Range(0, 100);
            var values = keys.AsParallel().AsOrdered().WithDegreeOfParallelism(3).Select(getItem);

            return keys.Zip(values, (k, v) => new KeyValuePair<int, string>(k, v))
                       .ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}
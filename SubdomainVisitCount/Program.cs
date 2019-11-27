using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SubdomainVisitCount
{
    /// <summary>
    /// Example 1:
    /// Input: 
    /// ["9001 discuss.leetcode.com"]
    /// Output: 
    /// ["9001 discuss.leetcode.com", "9001 leetcode.com", "9001 com"]
    /// Explanation: 
    /// We only have one website domain: "discuss.leetcode.com". As discussed 
    /// above, the subdomain "leetcode.com" and "com" will also be visited.
    /// So they will all be visited 9001 times.
    /// 
    /// Example 2:
    /// Input: 
    /// ["900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org"]
    /// Output: 
    /// ["901 mail.com","50 yahoo.com","900 google.mail.com","5 wiki.org","5 org","1 intel.mail.com","951 com"]
    /// Explanation: 
    /// We will visit "google.mail.com" 900 times, "yahoo.com" 50 times, "intel.mail.com" once and "wiki.org" 
    /// 5 times.For the subdomains, we will visit "mail.com" 900 + 1 = 901 times, "com" 900 + 50 + 1 = 951 times,
    /// and "org" 5 times.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[] { "900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org" };
            var solution = new Solution();
            var result = solution.SubdomainVisits(input);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Solution
    {
        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            var result = new List<string>();
            var dict = new Dictionary<string, int>();
            
            foreach(var item in cpdomains)
            {
                var strArr = item.Split(' ');
                var times = int.Parse(strArr[0]);
                var domain = strArr[1];

                while (true)
                {
                    if(dict.ContainsKey(domain) == false)
                    {
                        dict.Add(domain, times);
                    }
                    else
                    {
                        dict[domain] = dict[domain] + times;
                    }

                    var firstIndex = domain.IndexOf('.');
                    if (firstIndex == -1) break;
                    domain = domain.Substring(firstIndex + 1, domain.Length - firstIndex - 1);
                }
            }

            return dict.Select(x => $"{x.Value} {x.Key}").ToList();
        }
    }
}

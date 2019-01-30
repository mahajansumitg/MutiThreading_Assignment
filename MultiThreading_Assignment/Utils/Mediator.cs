﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading_Assignment.Utils
{
    public static class Mediator
    {
        private static Dictionary<string, Object> varDictionary = new Dictionary<string, Object>();

        public static void registerVar(string key, Object obj)
        {
            varDictionary.Add(key, obj);
        }
       
        public static Object getVar(string key)
        {
            Object obj;
            varDictionary.TryGetValue(key, out obj);
            return obj;
        }

        public static void removeVar(string key)
        {
            varDictionary.Remove(key);
        }
    }
}

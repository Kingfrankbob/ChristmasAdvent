using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day5
{

    public class Stack
    {
        private List<char> _stack = new List<char>();
        public void Push(char obj)
        {
            if (obj == null)
            {
                throw new InvalidOperationException("Null is not allowed");
            }
            _stack.Add(obj);
        }
        public char Pop()
        {
            if (_stack.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var obj = _stack[_stack.Count - 1];
            _stack.RemoveAt(_stack.Count - 1);
            return obj;
        }
        public void Clear()
        {
            _stack.Clear();
        }
        public int Count
        {
            get
            {
                return _stack.Count;
            }
        }
        public char last
        {
            get
            {
                return _stack[_stack.Count - 1];
            }
        }
    }

}
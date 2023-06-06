using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges1.Udemy25
{
    public class Node<T>
    {
        private T _data;
        private List<Node<T>> _children;
        Node<T>[] _chiles = new Node<T>[] { };

        public Node(T data)
        {
            _data = data;
            _children = new List<Node<T>>();
        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            _children.Add(node);
        }

        public void Remove(Node<T> node)
        {
            _children.Remove(node);
        }

        public bool Contains(T data)
        {

            return false;
        }
    }
}

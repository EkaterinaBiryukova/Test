using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHashTable
{
    /// <summary>
    /// Hashtable with universal types
    /// can gethashcode for int like %N
    /// and for string like length
    /// can insert element in table, collision check bi list (myListNode)
    /// </summary>
    /// <typeparam name="K">is for key for hashcode</typeparam>
    /// <typeparam name="T">value, inserted in hashtable</typeparam>
    class myHashTable<K, T>
    {
        public myListNode<K, T>[] values = new myListNode<K, T>[16];
        private int size;
        public void Insert(K newKey, T newValue, int N)
        {
            for (int i = 0; i < size; i++)
            {
                if (values[i] != null && GetHashCode(values[i].head.GetKey(), N) == GetHashCode(newKey, N))
                {
                    values[i].addNode(newValue, newKey);
                    return;
                }
            }

            values[size] = new myListNode<K, T>();
            values[size].addNode(newValue, newKey);
            size++;
        }
        public void PrintHashTable(int N)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write("{0}: ", GetHashCode(values[i].head.GetKey(), N));
                values[i].PrintList();
                Console.WriteLine();
            }
        }
        public int GetSize()
        {
            return size;
        }
        public int GetHashCode(K newKey, int N)
        {
            if (newKey.GetType() == typeof(int))
            {
                return (Convert.ToInt32(newKey) % N);
            }
            else if (newKey.GetType() == typeof(string))
            {
                return (Convert.ToString(newKey).Length);
            }
            return 0;
        }

    }


    /// <summary>
    /// Node of the list
    /// Always have information about next node of list 
    /// or null if it is tail of list or empty list
    /// </summary>
    /// <typeparam name="K">for key (NOT HERE!!! INCORRECT)</typeparam>
    /// <typeparam name="T">for value of node of list</typeparam>
    class Node<K, T> //RENAME ListNode - this is bucket
    {

        private T value;
        private K key;
        private Node<K, T> next;

        public void Insert(T newValue, K newKey)
        {
            value = newValue;
            key = newKey;
        }


        // get; set
        public void SetValue(T val)
        {
            value = val;
        }
        public T GetValue()
        {
            return value;
        }
        public K GetKey()
        {
            return key;
        }
        public void SetNext(Node<K, T> next)
        {
            this.next = next;
        }
        public bool HasNext()
        {
            return (true ? this.next != null : false);
        }
        public Node<K, T> GetNext()
        {
            return (next);
        }


    }

    /// <summary>
    /// One way List of nodes
    /// always have information about first and last nodes
    /// insert always in tail with replace of the link "next" in node
    /// </summary>
    /// <typeparam name="K">for key (CHECK!!)</typeparam>
    /// <typeparam name="T">for value, inserted in node</typeparam>
    class myListNode<K, T>
    {
        public Node<K, T> head;
        public Node<K, T> tail;
        int count;

        public int Size()
        {
            return count;
        }
        public bool IsEmpty()
        {
            return (true ? count == 0 : false);
        }
        public void addNode(T newValue, K newKey)
        {
            Node<K, T> newNode = new Node<K, T>();
            newNode.Insert(newValue, newKey);

            if (head == null) // if list is empty
            {
                head = newNode;
            }
            else
            {
                tail.SetNext(newNode);
            }

            tail = newNode; // entry always in tail
            count++;
        }

        public void PrintList()
        {
            Node<K, T> current = new Node<K, T>();
            current = this.head;
            for (int i = 0; i < this.Size(); i++)
            {
                try
                {
                    Console.Write("{0}; ", current.GetValue());
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("For i = {0} null pointer", i);
                }
                current = current.GetNext();

            }
        }
    }
}


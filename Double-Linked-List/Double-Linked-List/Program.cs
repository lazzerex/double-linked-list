using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_Linked_List
{
    internal class Program
    {

        public class Node2
        {
            public object element;
            public Node2 flink, blink;
            public Node2()
            {
                element = null;
                flink = blink = null;
            }
            public Node2(object element)
            {
                this.element = element;
                flink = blink = null;
            }
        }

        public class DoubleLinkedList
        {
            public Node2 header;
            public DoubleLinkedList()
            {
                header = new Node2("Header");
            }

            private Node2 Find(object element)
            {
                Node2 current = new Node2();
                current = header;
                while (current.element != element)
                {
                    current = current.flink;
                }
                return current;
            }

            public void Insert(object newelement, object afterelement)
            {
                Node2 current = new Node2();
                Node2 newnode = new Node2(newelement);
                current = Find(afterelement);
                newnode.flink = current.flink;
                newnode.blink = current;
                current.flink = newnode;
            }

            public void Remove(object element)
            {
                Node2 current = Find(element);
                if (current.flink != null)
                {
                    current.blink.flink = current.flink;
                    current.flink.blink = current.blink;
                    current.flink = null;
                    current.blink = null;
                }
            }

            public Node2 FindLast()
            {
                Node2 current = new Node2();
                current = header;
                while (!(current.flink == null))
                    current = current.flink;
                return current;
            }

            public void Print()
            {
                //Node2 current = new Node2();
                // current = FindLast();
                //while (!(current.blink == null))
                //{
                //Console.WriteLine(current.element);
                //current = current.blink;
                //}

                Node2 current = header.flink; // Bắt đầu từ node đầu tiên sau header
                while (current != null)
                {
                    Console.WriteLine(current.element);
                    current = current.flink; // Di chuyển tiến về phía trước
                }
            }

            public void Swap(object element1, object element2)
            { 
                Node2 node1 = Find(element1);
                Node2 node2 = Find(element2);

                object temp = node1.element;
                node1.element = node2.element;
                node2.element = temp;
            }

            public void Sort()
            {
                bool swapped;
                Node2 current;
                Node2 lastNode = null;

                if (header.flink == null)
                    return;

                do
                {
                    swapped = false;
                    current = header.flink;

                    while (current.flink != lastNode)
                    {
                        if (current.element.ToString().CompareTo(current.flink.element.ToString()) > 0)
                        {
                            object temp = current.element;
                            current.element = current.flink.element;
                            current.flink.element = temp;
                            swapped = true;
                        }
                        current = current.flink;
                    }
                    lastNode = current;
                }
                while (swapped);
            }
        
            static void Main(string[] args)
            {
                DoubleLinkedList dlist = new DoubleLinkedList();
                dlist.Insert("First", "Header");
                dlist.Insert("Second", "First");
                dlist.Insert("Third", "Second");
                dlist.Insert("David", "Third");
                dlist.Insert("Alice", "David");
                dlist.Insert("Charlie", "Alice");
                dlist.Insert("Bob", "Charlie");
                dlist.Insert("Eva", "Bob");
                //dlist.Print();
                /*Console.WriteLine("---");*/
                /*dlist.Remove("Second");
                dlist.Print();*/

                // dlist.Swap("First", "Third");
                //dlist.Print();
                Console.WriteLine("List");
                dlist.Print();

                dlist.Sort();

                Console.WriteLine("\nSorted");
                dlist.Print();

                Console.ReadLine();


               

            }
        }
    }
}

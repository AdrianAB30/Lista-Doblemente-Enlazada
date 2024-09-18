using System;

namespace Lista_Doblemente_Enlazada
{
    internal class Program
    {
        class DoubleLinkedList<T>
        {
            class Node
            {
                public T Value { get; set; }
                public Node Next { get; set; }
                public Node Previous { get; set; }

                public Node(T value)
                {
                    Value = value;
                    Next = null;
                    Previous = null;
                }
            }
            private int Count { get; set; }
            private Node Head { get; set; }

            public void AddStart(T value)
            {
                if (Head == null)
                {
                    Node newNode = new Node(value);
                    Head = newNode;
                }
                else
                {
                    Node newNode = new Node(value);
                    newNode.Next = Head;
                    Head.Previous = newNode;
                    Head = newNode;
                    ++Count;

                }
            }
            public void AddEnd(T value)
            {
                if(Head == null)
                {
                    AddStart(value);
                }
                else
                {
                    Node lastNode = SearchLastNode();
                    Node newNode = new Node(value);
                    lastNode.Next = newNode;
                    newNode.Previous = lastNode;
                    ++Count;
                }        
            }
            public void InsertNodeAtPosition(T value, int position)
            {
                if(position == 0)
                {
                    AddStart(value);

                }
                else if(position == Count)
                {
                    AddEnd(value);

                }
                else if(position > Count)
                {
                    throw new IndexOutOfRangeException("No se puedeee papito");
                }
                else
                {
                    Node newNode = new Node(value);
                    Node previosNode = Head;
                    int iterator = 0;
                    while (iterator < position - 1)
                    {
                        previosNode = previosNode.Next;
                        iterator = iterator + 1;
                    }
                    Node nextNode = previosNode.Next;
                    previosNode.Next = newNode;
                    newNode.Previous = previosNode;
                    newNode.Next = nextNode;
                    nextNode.Previous = newNode;
                    ++Count;
                }
                
            }
            public void ModifyAtStart(T value)
            {
                if(Head == null)
                {
                    throw new NullReferenceException("No se puede hacer eso pues");
                }
                else
                {
                    Head.Value = value;
                }
            }
            public void ModifyAtEnd(T value)
            {
                if(Head == null)
                {
                    ModifyAtStart(value);
                }
                else
                {
                    Node lastNode = SearchLastNode();
                    lastNode.Value = value;
                }
            }
            public void ModifyAtPosition(T value, int position)
            {
                if(Head == null)
                {
                    throw new NullReferenceException("No se puede tampoco pues");
                }
                else if(position == 0)
                {
                    ModifyAtStart(value); 
                }
                else if(position == Count)
                {
                    ModifyAtEnd(value);
                }
                else if(position > Count) 
                {
                    throw new NullReferenceException("Te pasaste mucho");
                }
                else
                {
                    Node positionNode = Head;
                    int iterator = 0;
                    while(iterator < position)
                    {
                        positionNode = positionNode.Next;
                        ++iterator;
                    }
                    positionNode.Value = value;
                }
            }
            public T GetAtStart()
            {
                if(Head == null)
                {
                    throw new NullReferenceException("No se puede papeto");
                }
                else
                {
                    return Head.Value;
                }
            }
            public T GetAtEnd()
            {
                if(Head == null)
                {
                    throw new NullReferenceException("La lista esta vacia");
                }
                else
                {
                    Node lastNode = SearchLastNode() ;
                    return lastNode.Value;
                }
            }
            public T GetNodeAtPosition(int position)
            {
                if (Head == null)
                {
                    throw new NullReferenceException("No existe");
                }
                else if (position == 0)
                {
                    return GetAtStart();
                }
                else if (position == Count)
                {
                    return GetAtEnd();
                }
                else if(position > Count)
                {
                    throw new NullReferenceException("Te pasaste de la lista papito");
                }
                else
                {
                    Node newPositionNode = Head;
                    int iterator = 0;
                    while(iterator < position)
                    {
                        newPositionNode = newPositionNode.Next;
                        ++iterator;
                    }
                    return newPositionNode.Value;
                }
            }
            public void DeleteAtStart()
            {
                if(Head == null)
                {
                    throw new NullReferenceException("La lista esta Vacia");
                }
                else
                {
                    Node newHead = Head.Next;
                    Head.Next = null;
                    newHead.Previous = null;
                    Head = null;
                    Head = newHead;
                    ++Count;
                }
            }
            public void DeleteAtEnd()
            {
                if (Head == null)
                {
                    throw new NullReferenceException("La lista esta Vacia");
                }
                else
                {
                    Node lastNode = SearchLastNode();
                    Node previousLastNode = lastNode.Previous;
                    previousLastNode.Next = null;
                    lastNode.Previous = null;
                    lastNode = null;
                }
            }
            public void DeleteAtPosition(int position)
            {
                if (position == 0)
                {
                    DeleteAtStart();
                }
                else if (position == Count - 1)
                {
                    DeleteAtEnd();
                }
                else if (position >= Count)
                {
                    throw new Exception("No se puede Papeto");
                }
                else
                {
                    Node nodePosition = Head;
                    int iterator = 0;
                    while (iterator < position)
                    {
                        nodePosition = nodePosition.Next;
                        iterator = iterator + 1;
                    }
                    Node previousNode = nodePosition.Previous;
                    Node nextNode = nodePosition.Next;
                    previousNode.Next = nextNode;
                    nextNode.Previous = previousNode;
                    nodePosition.Previous = null;
                    nodePosition.Next = null;
                    nodePosition = null;
                    ++Count;
                }
            }
            public T GetPreviousNodeValue(T value)
            {
                Node current = Head;

                while (current != null)
                {
                    dynamic currentValue = current.Value;
                    dynamic searchedValue = value;

                    if (currentValue == searchedValue)
                    {
                        if (current.Previous != null)
                        {
                            return current.Previous.Value;
                        }
                        else
                        {
                            throw new Exception("El nodo no tiene un nodo anterior.");
                        }
                    }
                    current = current.Next;
                }

                throw new Exception("El valor no se encuentra en la lista.");
            }
            public int CountNodeOccurrences(T value)
            {
                Node current = Head;
                int count = 0;

                while (current != null)
                {
                    dynamic currentValue = current.Value;
                    dynamic searchedValue = value;

                    if (currentValue == searchedValue)
                    {
                        count++;
                    }
                    current = current.Next;
                }

                return count;
            }
            public void PrintAllNodes()
            {
                Console.Write("Lista Doblemente Enlazada\n");
                Node tmp = Head;
                while(tmp != null)
                {
                    Console.Write(tmp.Value + " - ");
                    tmp = tmp.Next;
                }
                Console.WriteLine();
            }
            public void PrintAllNodesInReverse()
            {
                Console.Write("Lista en Reversa\n");
                Node tmp = SearchLastNode();
                while (tmp != null)
                { 
                    Console.Write(tmp.Value + " - ");
                    tmp = tmp.Previous;
                }
                Console.WriteLine();
            }
            private Node SearchLastNode()
            {
                Node lastNode = Head;
                while(lastNode.Next != null)
                {
                    lastNode = lastNode.Next; 
                }
                return lastNode;
            }
        }
        static void Main(string[] args)
        {
            DoubleLinkedList<int> doubleLinkedList = new DoubleLinkedList<int>();
            doubleLinkedList.AddStart(7);
            doubleLinkedList.AddStart(2);  
            doubleLinkedList.AddStart(3);
            doubleLinkedList.AddEnd(8);
            doubleLinkedList.InsertNodeAtPosition(9,2);
            doubleLinkedList.PrintAllNodes();
            doubleLinkedList.PrintAllNodesInReverse();
            Console.WriteLine();
            Console.WriteLine("Despues de Modificar");
            Console.WriteLine();
            doubleLinkedList.ModifyAtStart(1);
            doubleLinkedList.ModifyAtEnd(9);
            doubleLinkedList.ModifyAtPosition(5,3);
            doubleLinkedList.PrintAllNodes();
            doubleLinkedList.PrintAllNodesInReverse();
            Console.WriteLine();
            Console.WriteLine("Obtener Posiciones");
            Console.WriteLine("Inicio: " + doubleLinkedList.GetAtStart());
            Console.WriteLine("Final: " + doubleLinkedList.GetAtEnd());
            Console.WriteLine("Posicion 3: " + doubleLinkedList.GetNodeAtPosition(3));
            Console.WriteLine();         
            doubleLinkedList.PrintAllNodes();
            doubleLinkedList.PrintAllNodesInReverse();
            Console.WriteLine();
            Console.WriteLine("Metodos de Tarea");
            Console.WriteLine("Nodo Anterior a 5: " + doubleLinkedList.GetPreviousNodeValue(5));
            Console.WriteLine("Cuantas veces se repite el nodo 9: " + doubleLinkedList.CountNodeOccurrences(9));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GO LEFT");

            Console.ReadLine();

        }
    }
}

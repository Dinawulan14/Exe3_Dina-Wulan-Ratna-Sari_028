using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber; //Mendeskripsikan variabel rollnumber dengan tipe data integer
        public string name;//Mendeklarasikan variabel name dengan tiipe data string
        public string nim;//Mendeklarasikan variabel nim dengan tipe data string
        public Node next;//Mendekkripsikann variabel next dengan tipe node
    }
    class CircularList
    {
        Node LAST;//Mendeklarasikan node dengan nama "LAST"

        public CircularList()//nama kelas circularlist
        {
            LAST = null;//Mendeklarasikan node dengan nama LAST
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        /*Searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);/*returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber)/*If the node is present at the end*/
                return true;
            else
                return (false);/*returns false if the node is not found*/
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false; 
        }

        public void traverse()/*Traverses all the nodes of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + " " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first records in the list is:\n\n" + LAST.next.rollNumber + " " + LAST.next.name);
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a records in the list");
                    Console.WriteLine("3. Display the first records in the list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                //Akan memanggil dan menjalankan metode untuk menambah data
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                //Jika method list empty benrnilai benar
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                //Node prev dan curr
                                Node prev, curr;
                                //Menginisiasi prev dan curr dengan nilai null
                                prev = curr = null;
                                //Menampilkan kalimat arahan untuk memasukkan rol number
                                Console.Write("\nEnter the roll number of the student whose records is to be searched: ");
                                //Membaca inputan dan simpan ke dalam variabel num
                                int num = Convert.ToInt32(Console.ReadLine());
                                //Pengambilan keputusan if else
                                //Jika bernilai benar
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    //Maka records tidak ditemukan
                                    Console.WriteLine("\nRecords not found");
                                //lainnya
                                else
                                {
                                    //Record ditemukan
                                    Console.WriteLine("\nRecords found");
                                    //Menampilkan roll number
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    //Menampilkan nama mahasiswa
                                    Console.WriteLine("\nName: " + curr.name);
                                    //Menampilkan nim mahasiswa
                                    Console.WriteLine("\nStudent Number : " + curr.nim);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;

                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
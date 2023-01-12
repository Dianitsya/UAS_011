using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_011
{
    class Node
    {
        public int IdPel;
        public string Nama;
        public string JenisKelamin;
        public int NoHp;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addData()
        {
            int id, nohp;
            string nm, jk;
            Console.Write("\nMasukkan Id Pelanggan: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Pelanggan: ");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan Jenis Kelamin: ");
            jk = Console.ReadLine();
            Console.Write("\nMasukkan No Hp Pelanggan: ");
            nohp = Convert.ToInt32(Console.ReadLine());

            Node nodebaru = new Node();

            nodebaru.IdPel = id;
            nodebaru.Nama = nm;
            nodebaru.JenisKelamin = jk;
            nodebaru.NoHp = nohp;

            if (START == null || id <= START.IdPel)
            {
                if ((START != null) && (id == START.IdPel))
                {
                    Console.WriteLine("\nNomor buku sama tidak diizinkan");
                }
                nodebaru.next = START;
                START = nodebaru;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (id >= current.IdPel))
            {
                if (id == current.IdPel)
                {
                    Console.WriteLine("\nId pelanggan sama tidak diizinkan");
                    return;
                }
                previous = current;
                current = current.next;
            }

            nodebaru.next = current;
            previous.next = previous;
        }
        public bool Search(string nm, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (nm != current.Nama))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nData Pelanggan didalam list : ");
                Console.Write("Id" + "   " + "Nama" + "    " + "Jenis Kelamin" + "   " + "No Hp" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.IdPel + "    " + currentNode.Nama + "    " + currentNode.JenisKelamin + "         " + currentNode.NoHp + "\n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambah data kedalam list");
                    Console.WriteLine("2. Melihat semua data didalam list");
                    Console.WriteLine("3. Mencari sebuah data didalam list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nMasukkan Pilihan Anda (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addData();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList Kosong !");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan nama pelanggan yang akan dicari: ");
                                string nam = Console.ReadLine();
                                if (obj.Search(nam, ref previous, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                {
                                    Node nm;
                                    for (nm = current; nm != null; nm = nm.next)
                                    {
                                        Console.WriteLine("\nData Ketemu");
                                        Console.WriteLine("\nId Pelanggan : " + current.IdPel);
                                        Console.WriteLine("\nNama Pelanggan : " + current.Nama);
                                        Console.WriteLine("\nJenis Kelamin : " + current.JenisKelamin);
                                        Console.WriteLine("\nNo Hp: " + current.NoHp);
                                    }
                                }
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan tidak valid");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck data yang anda masukkan.");
                }

            }
        }
    }
}

// 2. Single Linked List : Lebih simple karna pada saat data baru akan dimasukkan hanya perlu
// membuat new node kemudian data bisa langsung dimasukkan kalau data yang depannya lebih besar

//3. Ditambhkan diakhir disebut top dan data yang dihapus paling terakhir disebut top

//4. Perbedaannya terletak di lokasi penyimpanan datanya,
// kalau array tidak bisa ditambah lagi/sudah ditentukan dan dipakai ketika banyaknya data sudah ditentukan
// sedangkan linked list bisa ditambahkan sebanyak banyaknya dan dipakai ketika memasukkan data yang jumlahnya banyak

//5. a. (10 dan 30) (5 dan 15) (20 dan 32) (10 dan 15) (20 dan 28)
//b. In Order (5,10,10,12,15,16,18,15,20,20,20,25,28,20,30,32)


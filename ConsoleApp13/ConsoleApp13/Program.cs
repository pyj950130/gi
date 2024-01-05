using System;
using System.Net.Security;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Linq;


struct Item
{
    public bool Id;
    public bool sell_check;
    public string Name;
    public int him;
    public int def;
    public string memo;
    public int sellgold;
    
    
    public void Pri(int pripass)
    {
        Console.Write($"{pripass}");
        if(Id == true)
        {
            Console.Write($"[E]");
        }
        else
        {
            Console.Write($"   ");
        }
        Console.Write($"{Name}\t");
        Console.Write($"| 공격력 : {him}\t");
        Console.Write($"| 방어력 : {def}\t");
        Console.Write($"| {memo}\t");
        if(sell_check==true)
        { 
            Console.WriteLine($"| {sellgold}G\t");
        }
        else
        { 
            Console.WriteLine($"| 구매완료\t");
        }
    }
}

struct Person
{
    public Item[] W_arry;
    public int Level;
    public string Name;
    public int Pw;
    public int Def;
    public int Heal;
    public int Gold;
    public int Has_weapon;
    public int Plus_st;
    public void Ma()
    {
        Console.WriteLine("Lv : " + Level);
        Console.WriteLine(Name);
        Console.WriteLine("공격력 : " + Pw + "("+ W_check_attack() + ")");
        Console.WriteLine("방어력 : " + Def + "(" + W_check_shield() + ")");
        Console.WriteLine("체력 : " + Heal);
        Console.WriteLine("소지 골드 : " + Gold + "G");
    }
    public int W_check_attack()
    {
        int demage = 0;
        for(int i=0;i<Has_weapon;i++)
        {
            if (W_arry[i].Id==true)
            {
                demage = W_arry[i].him;
            }
        }
        return demage;
    }
    public int W_check_shield()
    {
        int def = 0;
        for (int i = 0; i < Has_weapon; i++)
        {
            if (W_arry[i].Id == true)
            {
                def = W_arry[i].def;
            }
        }
        return def;
    }
}

namespace ConsoleApp13
{

    internal class Program
    {
        static void Inventory(Person[] player)
        {
            bool contoller = true;
            while (contoller)
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]\n");
                for (int i = 0; i < player[0].Has_weapon; i++)
                    //player[0]번째의 Has_weapon(가지고 있는 무기 - 미구연)
                {
                    //pleyer[0]째의 W_arry[i]번째의 Pri(i)번째 함수를 출력한다.
                    player[0].W_arry[i].Pri(i);
                }
                Console.WriteLine("\n");
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                string input = Console.ReadLine();//문자열로 콘솔 입력값을 받는다.
                int num1 = int.Parse(input);//받은 입력값을 int형으로 num1 바꾼다.

                if (num1 == 0)
                {
                    //contoller -> false형으로 바꿔서 while 반복문 조건을 끝낸다.
                    contoller = false;
                }
                else if (num1 == 1)
                {
                    Console.WriteLine("장착 관리");
                    Console.WriteLine("착용할 아이템 번호를 입력해주세요.\n");
                    for (int i = 0; i < player[0].Has_weapon; i++)
                    {
                        player[0].W_arry[i].Pri(i);
                    }
                    string W_input = Console.ReadLine();
                    int num2 = int.Parse(W_input);
                    player[0].Pw += player[0].W_arry[num2].him;
                    player[0].Def += player[0].W_arry[num2].def;
                }
            }

        }
        

        static void Statis(Person per1)
        {
            bool contoller = true;
            //불러오기
            while (contoller)
            {
                Console.Clear();
                Console.WriteLine("상태 보기.");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
                per1.Ma();
                Console.WriteLine("\n");
                Console.WriteLine("0.나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                string input = Console.ReadLine();
                int num1 = int.Parse(input);
                if(num1 == 0) 
                {
                    contoller=false;
                }
                else
                {
                    Console.WriteLine("잘못된 값입니다. 다시 입력해주세요.");
                }
            }
        }
        static void Store(Item[] itempass)
        {
            int num = 0;
            bool contoller = true;
            while (contoller)
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine("{0}G");
                Console.WriteLine("");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        contoller = false;
                        break;
                    case "1":
                        for (int i = 0; i < itempass.Length; i++)
                        {
                            itempass[i].Pri(i);
                        }
                        string numinput = Console.ReadLine();
                        num = int.Parse(numinput);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                        break;
                }
            }
        }
        static void entergame()
        {
            //게임 진입
            bool a = true;
            Person[] people = new Person[1];
            {
                people[0].W_arry = new Item[3];
                people[0].Level = 01;
                people[0].Name = "Chad ( 전사 )";
                people[0].Pw = 10;
                people[0].Def = 5;
                people[0].Heal = 100;
                people[0].Gold = 1500;
                people[0].Has_weapon = 0;
            }
            Item[] items = new Item[4];
            //아이템 데이터 입력
            {
                items[0].Id = false;
                items[0].Name = "빈손";
                items[0].him = 0;
                items[0].def = 0;
                items[0].memo = "빈손";
                items[1].Id = true;
                items[1].Name = "무쇠갑옷";
                items[1].def = 5;
                items[1].him = 0;
                items[1].memo = "무쇠로 만들어져 튼튼한 갑옷입니다.";
                items[2].Id = true;
                items[2].Name = "스파르타의 창";
                items[2].him = 7;
                items[2].def = 0;
                items[2].memo = "스파르타의 전사들이 사용했다는 전설의 창입니다.";
                items[3].Id = false;
                items[3].Name = "녹슨 검";
                items[3].him = 2;
                items[3].def = 0;
                items[3].memo = "쉽게 볼 수 있는 낡은 검입니다.";
            }
            while (a)
            {

                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                string number = Console.ReadLine();


                switch (number)
                {
                    case "1":
                        //Statis 함수의 (people[])<-매개변수/ [i]<-i번째 배열
                        Statis(people[0]);
                        break;
                    case "2":
                        //Inventory 함수의 (people)<-매개변수/ 
                        Inventory(people);
                        break;
                    case "3":
                        //store(item) 함수에 필요한 구조체 변수 Items 라는 이름을 가진 변수를 넣어 함수를 사용한다
                        //store 함수는 장비를 사기 위해 만들어진 함수이다
                        Store(items);
                        break;
                    case "4":
                        //a 값에 flase를 넣음으로써 While문의 조건이 false가 되어 반복이 종료된다.
                        a = false;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
        

        static void Main(string[] args)
        {
            entergame();
        }
    }
}
